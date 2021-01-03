using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;


public class ImageDownloader : MonoBehaviour
{
    //http://imscorgau.ipage.com/cinnzeo/ImageCounter.php
    //http://localhost/cinnzeo/GetDimensions.php
    public int W, H;
    public int imageIndex;
    public RawImage menuImage;

    public GameObject internetCheck;
    // Start is called before the first frame update
    void Start()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;

        StartCoroutine(checkInternet((isConnected) => {
             if (isConnected)
             {
                 Debug.Log("Internet Available!");
                 StartCoroutine(GetDynamicWH());
             }
             else
             {
                 Debug.Log("Internet Not Available");
                 internetCheck.SetActive(true);
             }
         }));
    }
    IEnumerator checkInternet(Action<bool> action)
    {
        WWW www = new WWW("http://google.com");
        yield return www;
        if (www.error != null)
        {
            action(false);
        }
        else
        {
            action(true);
        }
    }
     
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.LoadLevel(0);


    }

    IEnumerator GetDynamicWH()
    {
       
        using (var w = UnityWebRequest.Post("http://imscorgau.ipage.com/cinnzeo/GetDimensions.php", ""))
        {
            yield return w.SendWebRequest();

            if (w.isNetworkError || w.isHttpError)
            {
                print(w.error);
            }
            else
            {
                print(w.downloadHandler.text.ToString());
                int separation = w.downloadHandler.text.IndexOf('x');
                W = int.Parse(w.downloadHandler.text.Substring(0, separation));
                H = int.Parse(w.downloadHandler.text.Substring(++separation));
 
                RectTransform rt = menuImage.gameObject.GetComponent<RectTransform>();
                rt.sizeDelta = new Vector2(W, H);


                StartCoroutine(DownloadImage());
            }
        }
    }
    // Update is called once per frame
    IEnumerator DownloadImage()
    {


        using (var w = UnityWebRequest.Post("http://imscorgau.ipage.com/cinnzeo/ImageCounter.php", ""))
        {
            yield return w.SendWebRequest();

            if (w.isNetworkError || w.isHttpError)
            {
                print(w.error);
            }
            else
            {
                print(w.downloadHandler.text.ToString());
                imageIndex = int.Parse(w.downloadHandler.text.ToString());
            }
        }



        var www = new WWW("http://imscorgau.ipage.com/cinnzeo/Images/image" + imageIndex.ToString()+".png");
        // wait until the download is done
        yield return www;

        menuImage = GetComponent<RawImage>();
        menuImage.texture = www.texture;


        www = null;

    }
}
