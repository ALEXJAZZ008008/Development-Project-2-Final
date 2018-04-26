using API;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scenarios : MonoBehaviour
{
    public static bool m_UpdateScenario;
    public static int m_NextScenario;

    public static List<Choice> m_Choices;

    public static string m_VideoPath;
    public static string m_AmbientSoundPath;
    public static string m_NarrationPath;
    public static string m_SoundEffectPath;
    public static string m_OutputPath;
    public static string m_ScenarioText;
    public static string m_ScenarioChoiceText;

    public static List<float> m_FireArc;
    public static List<float> m_SmokeArc;

    public static float m_InTransitionLength;
    public static float m_VideoBrightness;
    public static float m_LightingIntensity;
    public static float m_AmbientSoundVolume;
    public static float m_NarrationVolume;
    public static float m_SoundEffectVolume;
    public static float m_ChoiceWaitLength;

    public static bool m_SmokeBool;
    public static bool m_FireBool;
    public static bool m_FireExtinguisherBool;
    public static bool m_EmergencyLightBool;
    public static bool m_SoundEffectBool;

    public static bool m_StartBool;
    public static bool m_SoundEffectWWWBool;

    public static string m_UniqueOutputPath;

    public static int m_Score;
    public static float m_Time;

    public GameObject smokeCanvas;
    public GameObject fireCanvas;
    public GameObject fireExtinguisherCanvas;
    public GameObject emergencyLight;
    public GameObject brightness;
    public GameObject soundEffect;

    public TextAsset defaultScenarioListJSON;

    public Text scenarioText;
    public Text scenarioChoiceText;

    public bool importScenarioBool;
    public bool defaultScenarioListBool;

    private ScenarioList scenarioList;

    private int currentScenario;

    private Material brightnessMaterial;

    private void DefaultScenario()
    {
        m_VideoPath = Application.dataPath + "/Scenarios/Assets/Videos/Scene1_video.mp4";
        m_AmbientSoundPath = Application.dataPath + "/Scenarios/Assets/Audio/AmbientHospital.wav";
        m_NarrationPath = Application.dataPath + "/Scenarios/Assets/Audio/Scene1_audio.wav";
        m_SoundEffectPath = Application.dataPath + "/Scenarios/Assets/Audio/Continuous.wav";
        m_OutputPath = Application.dataPath + "/Output";
        m_ScenarioText = "Please press space";
        m_ScenarioChoiceText = "What is the best course of action?";

        m_FireArc = new List<float> { 35.0f, 90.0f, 35.0f, 45.0f };
        m_SmokeArc = new List<float> { 35.0f, 90.0f, 35.0f, 45.0f };

        m_InTransitionLength = 3.0f;
        m_VideoBrightness = 1.0f;
        m_LightingIntensity = 0.25f;
        m_AmbientSoundVolume = 0.75f;
        m_NarrationVolume = 1.0f;
        m_SoundEffectVolume = 0.5f;
        m_ChoiceWaitLength = 5.0f;

        m_SmokeBool = false;
        m_FireBool = false;
        m_FireExtinguisherBool = false;
        m_EmergencyLightBool = false;
        m_SoundEffectBool = false;
    }

    private void UpdateCurrentScenario()
    {
        m_Choices = scenarioList.GetScenarios()[m_NextScenario].GetChoices();

        m_VideoPath = scenarioList.GetScenarios()[m_NextScenario].GetVideoPath();
        m_AmbientSoundPath = scenarioList.GetScenarios()[m_NextScenario].GetAmbientSoundPath();
        m_NarrationPath = scenarioList.GetScenarios()[m_NextScenario].GetNarrationPath();
        m_SoundEffectPath = scenarioList.GetScenarios()[m_NextScenario].GetSoundEffectPath();
        m_OutputPath = scenarioList.GetScenarios()[m_NextScenario].GetOutputPath();
        m_ScenarioText = scenarioList.GetScenarios()[m_NextScenario].GetScenarioText();
        m_ScenarioChoiceText = scenarioList.GetScenarios()[m_NextScenario].GetScenarioChoiceText();

        m_FireArc = scenarioList.GetScenarios()[m_NextScenario].GetFireArc();
        m_SmokeArc = scenarioList.GetScenarios()[m_NextScenario].GetSmokeArc();

        m_InTransitionLength = scenarioList.GetScenarios()[m_NextScenario].GetInTransitionLength();
        m_VideoBrightness = scenarioList.GetScenarios()[m_NextScenario].GetVideoBrightness();
        m_LightingIntensity = scenarioList.GetScenarios()[m_NextScenario].GetLightingIntensity();
        m_AmbientSoundVolume = scenarioList.GetScenarios()[m_NextScenario].GetAmbientSoundVolume();
        m_NarrationVolume = scenarioList.GetScenarios()[m_NextScenario].GetNarrationVolume();
        m_SoundEffectVolume = scenarioList.GetScenarios()[m_NextScenario].GetSoundEffectVolume();
        m_ChoiceWaitLength = scenarioList.GetScenarios()[m_NextScenario].GetChoiceWaitLength();

        m_SmokeBool = scenarioList.GetScenarios()[m_NextScenario].GetSmokeBool();
        m_FireBool = scenarioList.GetScenarios()[m_NextScenario].GetFireBool();
        m_FireExtinguisherBool = scenarioList.GetScenarios()[m_NextScenario].GetFireExtinguisherBool();
        m_EmergencyLightBool = scenarioList.GetScenarios()[m_NextScenario].GetEmergencyLightBool();
        m_SoundEffectBool = scenarioList.GetScenarios()[m_NextScenario].GetSoundEffectBool();

        if (m_NextScenario == 0)
        {
            m_UniqueOutputPath = m_OutputPath + "/output " + DateTime.UtcNow.Ticks.ToString() + ".txt";

            m_Score = 0;
            m_Time = 0.0f;

            m_StartBool = false;
        }
    }

    private void ImportScenarioList()
    {
        string[] commandLineArguments = Environment.GetCommandLineArgs();

        if (commandLineArguments.Length < 2 || defaultScenarioListBool)
        {
            JSONParser.JSONToTObject(defaultScenarioListJSON.text, ref scenarioList);
        }
        else
        {
            JSONParser.JSONToTObject(commandLineArguments[1], ref scenarioList);
        }

        UpdateCurrentScenario();
    }

    void Awake()
    {
        m_UpdateScenario = false;
        m_NextScenario = 0;

        m_Choices = new List<Choice>();

        m_VideoPath = string.Empty;
        m_AmbientSoundPath = string.Empty;
        m_NarrationPath = string.Empty;
        m_SoundEffectPath = string.Empty;
        m_OutputPath = string.Empty;
        m_ScenarioText = string.Empty;
        m_ScenarioChoiceText = string.Empty;

        m_FireArc = new List<float>();
        m_SmokeArc = new List<float>();

        m_InTransitionLength = 0.0f;
        m_VideoBrightness = 0.0f;
        m_LightingIntensity = 0.0f;
        m_AmbientSoundVolume = 0.0f;
        m_NarrationVolume = 0.0f;
        m_SoundEffectVolume = 0.0f;
        m_ChoiceWaitLength = 0.0f;

        m_SmokeBool = false;
        m_FireBool = false;
        m_FireExtinguisherBool = false;
        m_EmergencyLightBool = false;
        m_SoundEffectBool = false;

        m_StartBool = false;
        m_SoundEffectWWWBool = false;

        m_UniqueOutputPath = string.Empty;

        m_Score = 0;
        m_Time = 0.0f;

        currentScenario = 0;

        brightnessMaterial = brightness.GetComponent<Renderer>().material;

        if (importScenarioBool)
        {
            ImportScenarioList();
        }
        else
        {
            DefaultScenario();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (currentScenario != m_NextScenario)
        {
            if (m_NextScenario < 0 || m_NextScenario >= scenarioList.GetScenarios().Count)
            {
                Application.Quit();
            }

            UpdateCurrentScenario();

            currentScenario = m_NextScenario;
        }

        if (m_UpdateScenario)
        {
            smokeCanvas.SetActive(m_SmokeBool);
            fireCanvas.SetActive(m_FireBool);
            fireExtinguisherCanvas.SetActive(m_FireExtinguisherBool);
            emergencyLight.SetActive(m_EmergencyLightBool);
            soundEffect.SetActive(m_SoundEffectBool);

            Color colour = brightnessMaterial.color;

            colour.a = 1.0f - m_VideoBrightness;

            brightnessMaterial.color = colour;

            m_UpdateScenario = false;
        }

        if (scenarioText.text != m_ScenarioText)
        {
            scenarioText.text = m_ScenarioText;
        }

        if (scenarioChoiceText.text != m_ScenarioChoiceText)
        {
            scenarioChoiceText.text = m_ScenarioChoiceText;
        }
    }
}