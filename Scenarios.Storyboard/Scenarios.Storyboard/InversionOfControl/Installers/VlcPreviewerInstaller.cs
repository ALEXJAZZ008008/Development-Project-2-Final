using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Scenarios.Core;
using Scenarios.Storyboard.Vlc;

namespace Scenarios.Storyboard.InversionOfControl.Installers
{
    public class VlcPreviewerInstaller: IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IVideoPreviewer>()
                                        .Forward<IVideoThumbnailPreviewer>()
                                        .ImplementedBy <VlcMediaPreviewer>()
                                        .DependsOn(Dependency.OnValue("vlcPath", Properties.Settings.Default.vlcPath))
                                        .DependsOn(Dependency.OnValue("vlcDownloadPath", Properties.Settings.Default.vlcDownloadPath))
                                        .DependsOn(Dependency.OnValue("thumbnailPath", Properties.Settings.Default.thumbnailPath)));
        }
    }
}
