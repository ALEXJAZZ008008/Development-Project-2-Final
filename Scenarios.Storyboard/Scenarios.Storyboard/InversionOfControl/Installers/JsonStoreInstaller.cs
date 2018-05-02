using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Scenarios.Core;

namespace Scenarios.Storyboard.InversionOfControl.Installers
{
    public class JsonStoreInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IScenarioListStore>()
                                        .ImplementedBy<JsonScenarioListStore>()
                                        .DependsOn(Dependency.OnValue("storageFolder",
                                                                      Properties.Settings.Default.loadsavePath))
);
        }
    }
}
