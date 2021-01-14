using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;
using SimpleJSON;
using UnityEngine.Networking;

public class miniMenu : MonoBehaviour
{
    public struct ImageMenu
    {
        
        public Vector2 position;
        public Vector2 size;
        public RawImage image;
        public Texture txture;
    };



    string uploadDeviceID = "http://imscorgau.ipage.com/cinnzeo/minimenusizes/menuConfigs.php";
    //string uploadDeviceID = "http://localhost/cinnzeo/toptv/menuConfigs.php";


    int jsonIndex;
    int hrs, mins;
    Vector2 arrowSize;
    public GameObject hArrow;
    float yPosition;
    float AnimationSpeed;
    float AnimationTime;
    float AnimationDelay;
    float AnimationDelayEnd;
    public List<float> xPositions;
    public List<ImageMenu> LargeImages;
    public List<RawImage> SmallImages;
    string EaseType;
    int xCoutns;


    public RawImage LmenuImage;

    void Start()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        jsonIndex = -1;
        arrowSize = new Vector2();
        xPositions = new List<float>();
        SmallImages = new List<RawImage>();
        LargeImages = new List<ImageMenu>();


        StartCoroutine(CheckInternetConnection(isConnected =>
        {
            if (isConnected)
            {
                Debug.Log("Internet Available!");
                hArrow.GetComponent<Image>().color = Color.green;
                StartCoroutine(GetDeviceID());

            }
            else
            {
                Debug.Log("Internet Not Available");
            }
        }));


 
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.LoadLevel(0);


    }

    IEnumerator CheckInternetConnection(Action<bool> action)
    {
        UnityWebRequest request = new UnityWebRequest("http://google.com");
        yield return request.SendWebRequest();
        if (request.error != null)
        {
            Debug.Log("Error");
            action(false);
        }
        else
        {
            Debug.Log("Success");
            action(true);
        }
    }
    IEnumerator GetDeviceID()
    {
        // Create a Web Form
        WWWForm form = new WWWForm();
        form.AddField("deviceID", SystemInfo.deviceUniqueIdentifier.ToString());


        // Upload to a cgi script
        using (var w = UnityWebRequest.Post(uploadDeviceID, form))
        {
            yield return w.SendWebRequest();
            if (w.isNetworkError || w.isHttpError)
            {
                print(w.error);
            }
            else
            {
               // print(w.downloadHandler.text.ToString());
                if (w.responseCode.ToString() == "200" || w.downloadHandler.text.ToString() == "success")
                {
                    if (w.downloadHandler.text.ToString().Contains("empty for"))
                    {
                        hArrow.transform.GetChild(0).GetComponent<Text>().text = "Loading configs for:\n " +
                            w.downloadHandler.text.ToString().Substring(18).ToString();
                    }
                    else
                    {
                        hArrow.transform.GetChild(0).gameObject.SetActive(false);
                        StartCoroutine(SetupScreen(w.downloadHandler.text.ToString()));

                    }

                }
                else
                    hArrow.transform.GetChild(0).GetComponent<Text>().text = "Something went wrong :(";
            }

            
        }
    }
    // Update is called once per frame
    IEnumerator SetupScreen(string _config)
    {
        yield return new WaitForSeconds(1);
        var json = JSON.Parse(_config);

        //if active susbcription 
        if (json[0].Value == "False")
            yield return null;
        else
        {
            arrowSize.x = float.Parse(json[3].Value.ToString().Substring(0, json[3].Value.ToString().IndexOf("x")));
            arrowSize.y = float.Parse(json[3].Value.ToString().Substring(json[3].Value.ToString().IndexOf("x") + 1));
            hArrow.transform.localScale = new Vector3(arrowSize.x, arrowSize.y, 1);
            string[] colorSpecs = json[4].Value.ToString().Split(',');
            hArrow.GetComponent<Image>().color = new Color(float.Parse(colorSpecs[0]), float.Parse(colorSpecs[1]), float.Parse(colorSpecs[2]));

            AnimationSpeed = float.Parse(json[5].Value.ToString());
            AnimationTime = float.Parse(json[6].Value.ToString());
            AnimationDelay = float.Parse(json[7].Value.ToString());
            AnimationDelayEnd = float.Parse(json[8].Value.ToString());
            EaseType = json[9].Value.ToString();
            yPosition = float.Parse(json[10].Value.ToString());



            xCoutns = json[11].Count;
            for (int i = 0; i < xCoutns; i++)
            {
                xPositions.Add(float.Parse(json[11][i][0].Value.ToString()));
            }

            hArrow.transform.localPosition = new Vector3(xPositions[0], yPosition, 0);



            //Downloading menu images
            ImageMenu _img_l; // = new ImageMenu();
            ImageMenu _img_s;//= new ImageMenu();

            for (int i = 0; i < json[12].Count; i++)
            {
                //large image
                _img_l = new ImageMenu();
                var www = new WWW(json[12][i][3].Value.ToString() + json[12][i][0].Value.ToString() + ".png");
                yield return www;
                LmenuImage.texture = www.texture;

                _img_l.image = LmenuImage;
                _img_l.txture = www.texture;
                www = null;



                _img_l.position.x = float.Parse(json[12][i][1].Value.ToString().Substring(0, json[12][i][1].Value.ToString().IndexOf("x")));
                _img_l.position.y = float.Parse(json[12][i][1].Value.ToString().Substring(json[12][i][1].Value.ToString().IndexOf("x") + 1));
                _img_l.size.x = float.Parse(json[12][i][2].Value.ToString().Substring(0, json[12][i][2].Value.ToString().IndexOf("x")));
                _img_l.size.y = float.Parse(json[12][i][2].Value.ToString().Substring(json[12][i][2].Value.ToString().IndexOf("x") + 1));
                LargeImages.Add(_img_l);

            }


            //Small image
            GameObject go;
            for (int i = 0; i < json[12].Count; i++)
            {
                go = new GameObject();
                go.AddComponent<RawImage>();
                go.name = "mini" + i.ToString();
                go.transform.parent = hArrow.transform.parent;
                var www2 = new WWW(json[12][i][7].Value.ToString() + json[12][i][4].Value.ToString() + ".png");
                yield return www2;
                go.GetComponent<RawImage>().texture = www2.texture;

                go.GetComponent<RectTransform>().sizeDelta = new Vector2();
                go.GetComponent<RectTransform>().localPosition = new Vector3();

                RectTransform rt = go.gameObject.GetComponent<RectTransform>();
                rt.sizeDelta = new Vector2(float.Parse(json[12][i][6].Value.ToString().Substring(0, json[12][i][6].Value.ToString().IndexOf("x"))), float.Parse(json[12][i][6].Value.ToString().Substring(json[12][i][6].Value.ToString().IndexOf("x") + 1)));
                rt.localPosition = new Vector3(float.Parse(json[12][i][5].Value.ToString().Substring(0, json[12][i][5].Value.ToString().IndexOf("x"))), float.Parse(json[12][i][5].Value.ToString().Substring(json[12][i][5].Value.ToString().IndexOf("x") + 1)), 0);
                SmallImages.Add(go.GetComponent<RawImage>());


            }

            // If time base
            if (json[1].Value.ToString() == "True")
            {
                hrs = int.Parse(json[2].Value.ToString().Substring(0, 2));
                mins = int.Parse(json[2].Value.ToString().Substring(3));
                int calcTime;
                calcTime = mins - DateTime.Now.Minute;

                StartCoroutine(startWorking(calcTime * 60));
            }
            else
            {
                StartCoroutine(startWorking(5.0f));
            }
        }


    }

    IEnumerator startWorking(float calcTime)
    {
        yield return new WaitForSeconds(calcTime);

          
        for (int i = 0; i < xCoutns; i++)
        {
             changeMenu(i);
            iTween.MoveTo(hArrow, iTween.Hash("y", yPosition, "x", xPositions[i], "speed", AnimationSpeed, "time", AnimationTime, "islocal", true, "EaseType", EaseType , "onComplete", "itweenCompleted", "onCompleteTarget", this.gameObject));
            yield return new WaitForSeconds(AnimationDelay);
            if (i == xCoutns - 1)
            {
                i = -1;
                yield return new WaitForSeconds(AnimationDelayEnd);
            }
        }

    }

    void itweenCompleted()
    {
       // print("1");
         
    }
    void changeMenu(int index)
    {
        /*SmenuImage = SmallImages[index].image;
        RectTransform rt = SmenuImage.gameObject.GetComponent<RectTransform>();
        rt.sizeDelta = new Vector2(SmallImages[index].size.x, SmallImages[index].size.y);
        rt.localPosition = new Vector3(SmallImages[index].position.x, SmallImages[index].position.y, 0);*/
         LmenuImage.texture = LargeImages[index].txture;
         RectTransform rt2 = LmenuImage.gameObject.GetComponent<RectTransform>();
        rt2.sizeDelta = new Vector2(LargeImages[index].size.x, LargeImages[index].size.y);
        rt2.localPosition = new Vector3(LargeImages[index].position.x, LargeImages[index].position.y, 0);

    }



}
