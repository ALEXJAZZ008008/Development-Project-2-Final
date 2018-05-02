using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Scenarios.Core;

namespace Scenarios.Storyboard.InversionOfControl.Installers
{
    public class UserFileSelectorInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IUserFileSelector>()
                                        .ImplementedBy<WindowsFileDialogFileSelector>());
        }
    }
}
