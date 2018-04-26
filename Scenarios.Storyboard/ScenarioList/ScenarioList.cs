using System.Collections.Generic;

namespace API
{
    public class ScenarioList
    {
        private List<Scenario> m_Scenarios;

        public ScenarioList()
        {
            m_Scenarios = new List<Scenario>();
        }

        public ScenarioList(List<Scenario> scenarios)
        {
            m_Scenarios = scenarios;
        }

        public ScenarioList(ScenarioList scenarioList)
        {
            m_Scenarios = scenarioList.GetScenarios();
        }

        public List<Scenario> GetScenarios()
        {
            return m_Scenarios;
        }

        public void SetScenarios(List<Scenario> scenarios)
        {
            m_Scenarios = scenarios;
        }
    }

    public class Scenario
    {
        /// <summary>
        /// The list of choices that can be made from this scenario.
        /// </summary>
        private List<Choice> m_Choices;

        /// <summary>
        /// If empty string, go back to start. DO NOT ALLOW EMPTY STRING, ESSPECIALLY ON FIRST SCENARIO. 
        /// If video path but wrong, then display error.
        /// </summary>
        private string m_VideoPath;

        /// <summary>
        /// If empty string, no sound. 
        /// Indicates the file path for the ambient sound file for the scenario.
        /// </summary>
        private string m_AmbientSoundPath;

        /// <summary>
        /// If empty string, no sound. 
        /// Indicates the file path for the narration file for the scenario.
        /// </summary>
        private string m_NarrationPath;

        /// <summary>
        /// If empty string, no sound. 
        /// Indicates the file path for the sound effect file for the scenario.
        /// </summary>
        private string m_SoundEffectPath;

        /// <summary>
        /// If empty string, no output. Must be empty after first scenario, I won't check again.
        /// Indicates the file path for the output file.
        /// </summary>
        private string m_OutputPath;

        /// <summary>
        /// Empty indicates no scenario text.
        /// </summary>
        private string m_ScenarioText;

        /// <summary>
        /// Empty indicates no scenario choice text.
        /// </summary>
        private string m_ScenarioChoiceText;

        /// <summary>
        /// 0 - start of left right arc
        /// 1 - start of top bottom arc
        /// 2 - end of left right arc
        /// 3 - end of top bottom arc
        /// repeats
        /// </summary>
        private List<float> m_FireArc;

        /// <summary>
        /// Sets in transition length.
        /// </summary>
        private float m_InTransitionLength;

        /// <summary>
        /// Sets emergency lighting intensity.
        /// </summary>
        private float m_VideoBrightness;

        /// <summary>
        /// Sets emergency lighting intensity.
        /// </summary>
        private float m_LightingIntensity;

        /// <summary>
        /// The ambient sound volume as a percentage (i.e. between 1 and 100).
        /// </summary>
        private float m_AmbientSoundVolume;

        /// <summary>
        /// The narration volume as a percentage (i.e. between 1 and 100).
        /// </summary>
        private float m_NarrationVolume;

        /// <summary>
        /// The sound effect volume as a percentage (i.e. between 1 and 100).
        /// </summary>
        private float m_SoundEffectVolume;

        /// <summary>
        /// Sets in choice length.
        /// </summary>
        private float m_ChoiceWaitLength;

        /// <summary>
        /// Indicates that the scenario has a smoke effect.
        /// </summary>
        private bool m_SmokeBool;

        /// <summary>
        /// Indicates the presence of a fire effect in the scenario.
        /// </summary>
        private bool m_FireBool;

        /// <summary>
        /// Indicates that the extinguisher effect should be activated. 
        /// </summary>
        private bool m_FireExtinguisherBool;

        /// <summary>
        /// Indicates that the emergency light should be activated. 
        /// </summary>
        private bool m_EmergencyLightBool;

        /// <summary>
        /// Indicates that the sound effect should be activated. 
        /// </summary>
        private bool m_SoundEffectBool;

        public Scenario()
        {
            m_Choices = new List<Choice>();

            m_VideoPath = string.Empty;
            m_AmbientSoundPath = string.Empty;
            m_NarrationPath = string.Empty;
            m_SoundEffectPath = string.Empty;
            m_OutputPath = string.Empty;
            m_ScenarioText = string.Empty;
            m_ScenarioChoiceText = string.Empty;

            m_FireArc = new List<float>();

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
        }

        public Scenario(Scenario scenario)
        {
            m_Choices = scenario.GetChoices();

            m_VideoPath = scenario.GetVideoPath();
            m_AmbientSoundPath = scenario.GetAmbientSoundPath();
            m_NarrationPath = scenario.GetNarrationPath();
            m_SoundEffectPath = scenario.GetSoundEffectPath();
            m_OutputPath = scenario.GetOutputPath();
            m_ScenarioText = scenario.GetScenarioText();
            m_ScenarioChoiceText = scenario.GetScenarioChoiceText();

            m_FireArc = scenario.GetFireArc();

            m_InTransitionLength = scenario.GetInTransitionLength();
            m_VideoBrightness = scenario.GetVideoBrightness();
            m_LightingIntensity = scenario.GetLightingIntensity();
            m_AmbientSoundVolume = scenario.GetAmbientSoundVolume();
            m_NarrationVolume = scenario.GetNarrationVolume();
            m_SoundEffectVolume = scenario.GetSoundEffectVolume();
            m_ChoiceWaitLength = scenario.GetChoiceWaitLength();

            m_SmokeBool = scenario.GetSmokeBool();
            m_FireBool = scenario.GetFireBool();
            m_FireExtinguisherBool = scenario.GetFireExtinguisherBool();
            m_EmergencyLightBool = scenario.GetEmergencyLightBool();
            m_SoundEffectBool = scenario.GetSoundEffectBool();
        }

        public Scenario(List<Choice> choices, string videoPath, string ambientSoundPath, string narrationPath, string soundEffectPath, string outputPath, string scenarioText, string scenarioChoiceText, List<float> fireArc, float inTransitionLength, float videoBrightness, float lightingIntensity, float ambientSoundVolume, float narrationVolume, float soundEffectVolume, float choiceWaitLength, bool smokeBool, bool fireBool, bool fireExtinguisherBool, bool emergencyLightBool, bool soundEffectBool)
        {
            m_Choices = choices;

            m_VideoPath = videoPath;
            m_AmbientSoundPath = ambientSoundPath;
            m_NarrationPath = narrationPath;
            m_SoundEffectPath = soundEffectPath;
            m_OutputPath = outputPath;
            m_ScenarioText = scenarioText;
            m_ScenarioChoiceText = scenarioChoiceText;

            m_FireArc = fireArc;

            m_InTransitionLength = inTransitionLength;
            m_VideoBrightness = videoBrightness;
            m_LightingIntensity = lightingIntensity;
            m_AmbientSoundVolume = ambientSoundVolume;
            m_NarrationVolume = narrationVolume;
            m_SoundEffectVolume = soundEffectVolume;
            m_ChoiceWaitLength = choiceWaitLength;

            m_SmokeBool = smokeBool;
            m_FireBool = fireBool;
            m_FireExtinguisherBool = fireExtinguisherBool;
            m_EmergencyLightBool = emergencyLightBool;
            m_SoundEffectBool = soundEffectBool;
        }

        public List<Choice> GetChoices()
        {
            return m_Choices;
        }

        public string GetVideoPath()
        {
            return m_VideoPath;
        }

        public string GetAmbientSoundPath()
        {
            return m_AmbientSoundPath;
        }

        public string GetNarrationPath()
        {
            return m_NarrationPath;
        }

        public string GetSoundEffectPath()
        {
            return m_SoundEffectPath;
        }

        public string GetOutputPath()
        {
            return m_OutputPath;
        }

        public string GetScenarioText()
        {
            return m_ScenarioText;
        }

        public string GetScenarioChoiceText()
        {
            return m_ScenarioChoiceText;
        }

        public List<float> GetFireArc()
        {
            return m_FireArc;
        }

        public float GetInTransitionLength()
        {
            return m_InTransitionLength;
        }

        public float GetVideoBrightness()
        {
            return m_VideoBrightness;
        }

        public float GetLightingIntensity()
        {
            return m_LightingIntensity;
        }

        public float GetAmbientSoundVolume()
        {
            return m_AmbientSoundVolume;
        }

        public float GetNarrationVolume()
        {
            return m_NarrationVolume;
        }

        public float GetSoundEffectVolume()
        {
            return m_SoundEffectVolume;
        }

        public float GetChoiceWaitLength()
        {
            return m_ChoiceWaitLength;
        }

        public bool GetSmokeBool()
        {
            return m_SmokeBool;
        }

        public bool GetFireBool()
        {
            return m_FireBool;
        }

        public bool GetFireExtinguisherBool()
        {
            return m_FireExtinguisherBool;
        }

        public bool GetEmergencyLightBool()
        {
            return m_EmergencyLightBool;
        }

        public bool GetSoundEffectBool()
        {
            return m_SoundEffectBool;
        }

        public void SetChoices(List<Choice> choices)
        {
            m_Choices = choices;
        }

        public void SetVideoPath(string videoPath)
        {
            m_VideoPath = videoPath;
        }

        public void SetAmbientSoundPath(string ambientSoundPath)
        {
            m_AmbientSoundPath = ambientSoundPath;
        }

        public void SetNarrationPath(string narrationPath)
        {
            m_NarrationPath = narrationPath;
        }

        public void SetSoundEffectPath(string soundEffectPath)
        {
            m_SoundEffectPath = soundEffectPath;
        }

        public void SetOutputPath(string outputPath)
        {
            m_OutputPath = outputPath;
        }

        public void SetScenarioText(string scenarioText)
        {
            m_ScenarioText = scenarioText;
        }

        public void SetScenarioChoiceText(string scenarioChoiceText)
        {
            m_ScenarioChoiceText = scenarioChoiceText;
        }

        public void SetFireArc(List<float> fireArc)
        {
            m_FireArc = fireArc;
        }

        public void SetInTransitionLength(float inTransitionLength)
        {
            m_InTransitionLength = inTransitionLength;
        }

        public void SetVideoBrightness(float videoBrightness)
        {
            m_VideoBrightness = videoBrightness;
        }

        public void SetLightingIntensity(float lightingIntensity)
        {
            m_LightingIntensity = lightingIntensity;
        }

        public void SetAmbientSoundVolume(float ambientSoundVolume)
        {
            m_AmbientSoundVolume = ambientSoundVolume;
        }

        public void SetNarrationVolume(float narrationVolume)
        {
            m_NarrationVolume = narrationVolume;
        }

        public void SetSoundEffectVolume(float soundEffectVolume)
        {
            m_SoundEffectVolume = soundEffectVolume;
        }

        public void SetChoiceWaitLength(float choiceWaitLength)
        {
            m_ChoiceWaitLength = choiceWaitLength;
        }

        public void SetSmokeBool(bool smokeBool)
        {
            m_SmokeBool = smokeBool;
        }

        public void SetFireBool(bool fireBool)
        {
            m_FireBool = fireBool;
        }

        public void SetFireExtinguisherBool(bool extinguisherBool)
        {
            m_FireExtinguisherBool = extinguisherBool;
        }

        public void SetEmergencyLightBool(bool emergencyLightBool)
        {
            m_EmergencyLightBool = emergencyLightBool;
        }

        public void SetSoundEffectBool(bool soundEffectBool)
        {
            m_SoundEffectBool = soundEffectBool;
        }
    }

    public class Choice
    {
        /// <summary>
        /// The scenario that the choice should go to. 
        /// </summary>
        private int m_NextScenarioIndex;

        /// <summary>
        /// The choice associated with the text.
        /// </summary>
        private string m_ChoiceText;

        /// <summary>
        /// The feedback given at the end if this choice has been made.
        /// </summary>
        private string m_FeedbackText;

        /// <summary>
        /// Positive choice - positive score
        /// Negative choice - negative score
        /// Neutral choice/no decision needed - zero
        /// </summary>
        private int m_Score;

        public Choice()
        {
            m_NextScenarioIndex = 0;

            m_ChoiceText = string.Empty;
            m_FeedbackText = string.Empty;

            m_Score = 0;
        }

        public Choice(Choice choice)
        {
            m_NextScenarioIndex = choice.GetNextScenarioIndex();

            m_ChoiceText = choice.GetChoiceText();
            m_FeedbackText = choice.GetFeedbackText();

            m_Score = choice.GetScore();
        }

        public Choice(int nextScenarioIndex, string choiceText, string feedbackText, int score)
        {
            m_NextScenarioIndex = nextScenarioIndex;

            m_ChoiceText = choiceText;
            m_FeedbackText = feedbackText;

            m_Score = score;
        }

        public int GetNextScenarioIndex()
        {
            return m_NextScenarioIndex;
        }

        public string GetChoiceText()
        {
            return m_ChoiceText;
        }

        public string GetFeedbackText()
        {
            return m_FeedbackText;
        }

        public int GetScore()
        {
            return m_Score;
        }

        public void SetNextScenarioIndex(int nextScenarioIndex)
        {
            m_NextScenarioIndex = nextScenarioIndex;
        }

        public void SetChoiceText(string choiceText)
        {
            m_ChoiceText = choiceText;
        }

        public void SetFeedbackText(string feedbackText)
        {
            m_FeedbackText = feedbackText;
        }

        public void SetScore(int score)
        {
            m_Score = score;
        }
    }
}