using Scenarios.Storyboard.ViewModels;

namespace Scenarios.Storyboard.Adapters
{
    public static class ScenarioViewModelToScenarioAdapter
    {
        public static API.Scenario Convert(ScenarioViewModel viewModel)
        {
            API.Scenario scenario = new API.Scenario();

            //Transition
            scenario.SetInTransitionLength(viewModel.VideoOptions.InTransitionLength);

            //Video
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

            //Sound
            scenario.SetAmbientSoundPath(viewModel.SoundOptions.AmbientSoundPath);
            scenario.SetNarrationPath(viewModel.SoundOptions.NarrationSoundPath);
            scenario.SetSoundEffectPath(viewModel.SoundOptions.SoundEffectPath);
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
