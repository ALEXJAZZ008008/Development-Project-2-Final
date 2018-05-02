using Scenarios.Core;
using Scenarios.Storyboard.ViewModels;
using System.Linq;

namespace Scenarios.Storyboard.Adapters
{
    public static class ScenarioViewModelToScenarioAdapter
    {
        public static API.Scenario Convert(ScenarioViewModel viewModel)
        {
            API.Scenario scenario = new API.Scenario();

            //Name
            scenario.SetName(viewModel.Name);

            //Transition
            scenario.SetInTransitionLength(viewModel.VideoOptions.InTransitionLength);

            //Video
            string unityVideoPath = 
                WindowsFilePathStringToUnityHelper.ConvertToUnityStyle(viewModel.VideoOptions.VideoFilePath);

            scenario.SetVideoPath(viewModel.VideoOptions.VideoFilePath);
            scenario.SetVideoBrightness((float)viewModel.VideoOptions.VideoBrightness / 100);

            //On-screen text
            scenario.SetScenarioText(viewModel.ScenarioText);

            //Particle effects & emergency lighting
            scenario.SetFireBool(viewModel.EffectOptions.FireIsEnabled);
            scenario.SetFireExtinguisherBool(viewModel.EffectOptions.FireExtinguisherPlumeIsEnabled);
            scenario.SetSmokeBool(viewModel.EffectOptions.SmokeIsEnabled);
            scenario.SetEmergencyLightBool(viewModel.EffectOptions.EmergencyLightingIsEnabled);
            scenario.SetLightingIntensity((float)viewModel.EffectOptions.EmergencyLightingIntensity / 100);

            //Fire & Smoke positioning
            scenario.SetFireArc(viewModel.EffectOptions.FireArcs.ToList());
            scenario.SetSmokeArc(viewModel.EffectOptions.SmokeArcs.ToList());

            //Sound
            string unityAmbientSoundPath =
                WindowsFilePathStringToUnityHelper.ConvertToUnityStyle(viewModel.SoundOptions.AmbientSoundPath);
            scenario.SetAmbientSoundPath(unityAmbientSoundPath);

            string unityNarrationSoundPath =
                WindowsFilePathStringToUnityHelper.ConvertToUnityStyle(viewModel.SoundOptions.NarrationSoundPath);
            scenario.SetNarrationPath(unityNarrationSoundPath);

            string unitySoundEffectPath =
                WindowsFilePathStringToUnityHelper.ConvertToUnityStyle(viewModel.SoundOptions.SoundEffectPath);
            scenario.SetSoundEffectPath(unitySoundEffectPath);

            scenario.SetAmbientSoundVolume(((float)viewModel.SoundOptions.AmbientSoundVolume / 100));
            scenario.SetNarrationVolume((float)viewModel.SoundOptions.NarrationSoundVolume / 100);
            scenario.SetSoundEffectBool(viewModel.SoundOptions.SoundEffectEnabledAtStart);
            scenario.SetSoundEffectVolume((float)viewModel.SoundOptions.SoundEffectVolume / 100);

            //Decision & Choices 
            scenario.SetScenarioChoiceText(viewModel.Decision.DecisionText);
            scenario.SetChoiceWaitLength(viewModel.Decision.DecisionWaitTime);

            return scenario;
        }
    }
}
