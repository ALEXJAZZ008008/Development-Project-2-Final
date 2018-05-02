using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Scenarios.Core;

namespace Scenarios.Storyboard.InversionOfControl.Installers
{
    public class UnityPlayerInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IUnityPlayer>()
                                        .ImplementedBy<JsonCommandLineArgUnityPlayer>()
                                        .DependsOn(Dependency.OnValue("unityPath", Properties.Settings.Default.unityPath))
                                        .LifestyleTransient());
        }
    }
}
