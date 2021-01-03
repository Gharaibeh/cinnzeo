using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
 

public class ImageUploader : MonoBehaviour
{
    public int imageIndex;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CountImages());
     }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            StartCoroutine(PostImageToPhp());
    }

    IEnumerator CountImages()
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
                imageIndex = int.Parse( w.downloadHandler.text.ToString());
            }
        }
    }
    public IEnumerator PostImageToPhp()
    {

        // We should only read the screen after all rendering is complete
        yield return new WaitForEndOfFrame();

        // Create a texture the size of the screen, RGB24 format
        int width = Screen.width;
        int height = Screen.height;
        var tex = new Texture2D(width, height, TextureFormat.RGB24, false);

        // Read screen contents into the texture
        tex.ReadPixels(new Rect(0, 0, width, height), 0, 0);
        tex.Apply();

        // Encode texture into PNG
        byte[] bytes = tex.EncodeToPNG();
        Destroy(tex);



        // Create a Web Form
        WWWForm form = new WWWForm();
        form.AddField("frameCount", Time.frameCount.ToString());
        form.AddBinaryData("file", bytes, "image"+(++imageIndex)+".png", "image/png");

        // Upload to a cgi script
        using (var w = UnityWebRequest.Post("http://imscorgau.ipage.com/cinnzeo/ImageUploader.php", form))
        {
            yield return w.SendWebRequest();
            if (w.isNetworkError || w.isHttpError)
            {
                print(w.error);
            }
            else
            {
                print("Finished Uploading Screenshot");
            }
        }
         
    }
}
