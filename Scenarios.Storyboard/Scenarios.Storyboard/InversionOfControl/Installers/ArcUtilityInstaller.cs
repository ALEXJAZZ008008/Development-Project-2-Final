using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Scenarios.Core;

namespace Scenarios.Storyboard.InversionOfControl.Installers
{
    public class ArcUtilityInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IFireArcUtility>()
                            .ImplementedBy<FireArc>()
                            .DependsOn(Dependency.OnValue("path", Properties.Settings.Default.fireArcPath)));
            container.Register(Component.For<ISmokeArcUtility>()
                                        .ImplementedBy<SmokeArc>()
                                        .DependsOn(Dependency.OnValue("path", Properties.Settings.Default.smokeArcPath)));
        }
    }
}
