using UnityEngine;
using UnityEngine.Video;

public class Visual : MonoBehaviour
{
    public GameObject video;
    public GameObject crosshair;

    private VideoPlayer videoPlayer;

    void Awake()
    {
        videoPlayer = video.GetComponent<VideoPlayer>();
    }

    private void OnEnable()
    {
        videoPlayer.targetTexture.Release();

        if (Arc.m_VideoPath != string.Empty)
        {
            videoPlayer.url = Arc.m_VideoPath;

            videoPlayer.Prepare();
        }
        else
        {
            Application.Quit();
        }
    }

    void StartChoices(VideoPlayer temporaryVideoPlayer)
    {
        if (Arc.m_Choices.Count > 1)
        {
            crosshair.SetActive(true);
        }
        else
        {
            if (Arc.m_Choices.Count == 1)
            {
                Arc.m_NextScenario = Arc.m_Choices[0].GetNextScenarioIndex();
            }
            else
            {
                Application.Quit();
            }
        }

        videoPlayer.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if (videoPlayer.isPrepared && !videoPlayer.isPlaying)
        {
            videoPlayer.Play();
        }

        videoPlayer.loopPointReached += StartChoices;
    }

    private void OnDisable()
    {
        videoPlayer.Stop();
    }
}