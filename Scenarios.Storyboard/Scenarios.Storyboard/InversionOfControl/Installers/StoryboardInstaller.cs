using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Scenarios.Storyboard.ViewModels;

namespace Scenarios.Storyboard.InversionOfControl.Installers
{
    public class StoryboardInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<StoryboardViewModel>()
                                        .ImplementedBy<StoryboardViewModel>());
        }
    }
}
