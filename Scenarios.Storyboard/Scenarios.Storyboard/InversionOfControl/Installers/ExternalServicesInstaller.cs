using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using MahApps.Metro.Controls.Dialogs;

namespace Scenarios.Storyboard.InversionOfControl.Installers
{
    public class ExternalServicesInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IDialogCoordinator>()
                                        .UsingFactoryMethod(() => DialogCoordinator.Instance));
        }
    }
}
