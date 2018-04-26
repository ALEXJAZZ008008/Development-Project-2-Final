using Castle.Facilities.TypedFactory;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Scenarios.Storyboard.Pages;

namespace Scenarios.Storyboard.InversionOfControl.Installers
{
    public class PageInstaller: IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromThisAssembly()
                                      .InSameNamespaceAs<StoryboardEditorPage>());
            container.Register(Component.For<IPageFactory>()
                                        .AsFactory());
        }
    }
}
