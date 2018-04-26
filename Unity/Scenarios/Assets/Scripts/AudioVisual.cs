using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.Video;

public class AudioVisual : MonoBehaviour
{
    public GameObject video;
    public GameObject fireExtinguisherCanvas;
    public GameObject outTransition;
    public GameObject crosshair;
    public GameObject choiceCanvas;
    public GameObject scenarioChoiceText;
    public GameObject countdownText;
    public GameObject ambientSound;
    public GameObject narration;
    public GameObject soundEffect;
    public GameObject fireSoundEffect;
    public GameObject fireExtinguisherSoundEffect;

    private VideoPlayer videoPlayer;
    private AudioSource ambientSoundSource;
    private AudioSource narrationSource;
    private AudioSource soundEffectSource;
    private AudioSource fireSoundEffectSource;
    private AudioSource fireExtinguisherSoundEffectSource;

    void Awake()
    {
        videoPlayer = video.GetComponent<VideoPlayer>();

        ambientSoundSource = ambientSound.GetComponent<AudioSource>();
        narrationSource = narration.GetComponent<AudioSource>();
        soundEffectSource = soundEffect.GetComponent<AudioSource>();
        fireSoundEffectSource = fireSoundEffect.GetComponent<AudioSource>();
        fireExtinguisherSoundEffectSource = fireExtinguisherSoundEffect.GetComponent<AudioSource>();
    }

    IEnumerator LoadAmbientSoundCoroutine()
    {
        WWW www = new WWW("file:///" + Scenarios.m_AmbientSoundPath);

        while (!www.isDone)
        {
            yield return www;
        }

        ambientSoundSource.clip = www.GetAudioClip(false, false);

        ambientSoundSource.Play();
    }

    IEnumerator LoadNarrationCoroutine()
    {
        WWW www = new WWW("file:///" + Scenarios.m_NarrationPath);

        while (!www.isDone)
        {
            yield return www;
        }

        narrationSource.clip = www.GetAudioClip(false, false);

        narrationSource.Play();
    }

    IEnumerator LoadSoundEffectCoroutine()
    {
        WWW www = new WWW("file:///" + Scenarios.m_SoundEffectPath);

        while (!www.isDone)
        {
            yield return www;
        }

        Scenarios.m_SoundEffectWWWBool = true;

        soundEffectSource.clip = www.GetAudioClip(false, false);
    }

    private void OnEnable()
    {
        videoPlayer.targetTexture.Release();

        if (File.Exists(Scenarios.m_VideoPath))
        {
            videoPlayer.url = Scenarios.m_VideoPath;

            videoPlayer.Prepare();
        }
        else
        {
            Application.Quit();
        }

        if (File.Exists(Scenarios.m_AmbientSoundPath))
        {
            StartCoroutine(LoadAmbientSoundCoroutine());
        }

        if (File.Exists(Scenarios.m_NarrationPath))
        {
            StartCoroutine(LoadNarrationCoroutine());
        }

        if (File.Exists(Scenarios.m_SoundEffectPath))
        {
            StartCoroutine(LoadSoundEffectCoroutine());
        }

        ambientSoundSource.volume = Scenarios.m_AmbientSoundVolume;
        narrationSource.volume = Scenarios.m_NarrationVolume;
        soundEffectSource.volume = Scenarios.m_SoundEffectVolume;
        fireSoundEffectSource.volume = Scenarios.m_SoundEffectVolume;
        fireExtinguisherSoundEffectSource.volume = Scenarios.m_SoundEffectVolume;
    }

    void StartChoices(VideoPlayer temporaryVideoPlayer)
    {
        if (fireExtinguisherCanvas.activeSelf)
        {
            fireExtinguisherCanvas.SetActive(false);
        }

        if (Scenarios.m_Choices.Count > 1)
        {
            crosshair.SetActive(true);
            choiceCanvas.SetActive(true);
            scenarioChoiceText.SetActive(true);
            countdownText.SetActive(true);
        }
        else
        {
            if (Scenarios.m_Choices.Count == 1)
            {
                Scenarios.m_NextScenario = Scenarios.m_Choices[0].GetNextScenarioIndex();
            }
            else
            {
                Application.Quit();
            }

            outTransition.SetActive(true);
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

        ambientSoundSource.Stop();

        if (narrationSource.isPlaying)
        {
            narrationSource.Stop();
        }
    }
}