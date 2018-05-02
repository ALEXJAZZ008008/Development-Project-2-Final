using Castle.Facilities.TypedFactory;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Scenarios.Storyboard.ViewModels.Factories;

namespace Scenarios.Storyboard.InversionOfControl.Installers
{
    public class ViewModelFactoryInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IScenarioViewModelFactory>()
                                        .AsFactory());
            container.Register(Component.For<IVideoOptionsViewModelFactory>()
                                        .AsFactory());
            container.Register(Component.For<ISoundOptionsViewModelFactory>()
                                        .AsFactory());
            container.Register(Component.For<IDecisionViewModelFactory>()
                                        .AsFactory());
            container.Register(Component.For<IEffectOptionsViewModelFactory>()
                                        .AsFactory());
            container.Register(Component.For<IChoiceViewModelFactory>()
                                        .AsFactory());
        }
    }
}
