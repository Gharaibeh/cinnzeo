using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class videotest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        // Will attach a VideoPlayer to the main camera.
        /* GameObject camera = GameObject.Find("MainCamera");

         // VideoPlayer automatically targets the camera backplane when it is added
         // to a camera object, no need to change videoPlayer.targetCamera.
         var videoPlayer = camera.AddComponent<UnityEngine.Video.VideoPlayer>();



         // Play on awake defaults to true. Set it to false to avoid the url set
         // below to auto-start playback since we're in Start().
         videoPlayer.playOnAwake = false;

         // By default, VideoPlayers added to a camera will use the far plane.
         // Let's target the near plane instead.
         videoPlayer.renderMode = UnityEngine.Video.VideoRenderMode.CameraNearPlane;

         // This will cause our Scene to be visible through the video being played.
         videoPlayer.targetCameraAlpha = 0.5F;

         // Set the video to play. URL supports local absolute or relative paths.
         // Here, using absolute.

         // Skip the first 100 frames.
         videoPlayer.frame = 100;

         // Restart from beginning when done.
         videoPlayer.isLooping = true;

         // Each time we reach the end, we slow down the playback by a factor of 10.
         //videoPlayer.loopPointReached += EndReached;

         // Start playback. This means the VideoPlayer may have to prepare (reserve
         // resources, pre-load a few frames, etc.). To better control the delays
         // associated with this preparation one can use videoPlayer.Prepare() along with
         // its prepareCompleted event.
         videoPlayer.clip = Resources.Load<VideoClip>("Cinnzeo.mp4") as VideoClip;
         videoPlayer.Play();*/

        StartCoroutine(playNext());
    }


    IEnumerator playNext()
    {

        yield return new WaitForSeconds(1);
        //flour
        Handheld.PlayFullScreenMovie("Cinnzeo Rolling 6 Flour.mp4", Color.white, FullScreenMovieControlMode.Hidden);
        yield return new WaitForSeconds(1);

        // mixing cinnamon
        Handheld.PlayFullScreenMovie("Cinnzeo Mixing Cinnamon.mp4", Color.black, FullScreenMovieControlMode.Hidden);
        yield return new WaitForSeconds(1);

        // rolling dough
        Handheld.PlayFullScreenMovie("Cinnzeo Rolling 2.mp4", Color.black, FullScreenMovieControlMode.Hidden);
        yield return new WaitForSeconds(1);
        //putting cinnamon
        Handheld.PlayFullScreenMovie("Cinnzeo Rolling 3.mp4", Color.black, FullScreenMovieControlMode.Hidden);

        yield return new WaitForSeconds(1);

        //rolling cinnamon
        Handheld.PlayFullScreenMovie("Cinnzeo Rolling 4.mp4", Color.black, FullScreenMovieControlMode.Hidden);
        yield return new WaitForSeconds(1);

        // before over
        Handheld.PlayFullScreenMovie("Cinnzeo Rolls Ready to bake.mp4", Color.black, FullScreenMovieControlMode.Hidden);
        yield return new WaitForSeconds(1);

        //aftr over
        Handheld.PlayFullScreenMovie("Cinnzeo Rolls into oven.mp4", Color.black, FullScreenMovieControlMode.Hidden);
        yield return new WaitForSeconds(1);


        //putting cream on top
        Handheld.PlayFullScreenMovie("Cinnzeo Rolls Frosting.mp4", Color.black, FullScreenMovieControlMode.Hidden);

        yield return new WaitForSeconds(1);

        //putting cream on top
        Handheld.PlayFullScreenMovie("Cinnzeo Rolls Sliding.mp4", Color.black, FullScreenMovieControlMode.Hidden);

        yield return new WaitForSeconds(1);

        // sliding on plate
        Handheld.PlayFullScreenMovie("Cinnzeo_021.mp4", Color.black, FullScreenMovieControlMode.Hidden);
        yield return new WaitForSeconds(1);


        // boxing
        Handheld.PlayFullScreenMovie("boxing.mp4", Color.black, FullScreenMovieControlMode.Hidden);

        yield return new WaitForSeconds(1);


    }


}
