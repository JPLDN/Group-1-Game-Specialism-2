using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class CutscenePlayer : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    private SceneSwitcher sceneSwitcher;

    // Start is called before the first frame update
    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        sceneSwitcher = GetComponent<SceneSwitcher>();
        videoPlayer.loopPointReached += OnVideoFinished;
    }

    // Switches scenes after the cutscene finishes playing
    void OnVideoFinished(VideoPlayer vp)
    {
        sceneSwitcher.SwitchScene();
    }
}
