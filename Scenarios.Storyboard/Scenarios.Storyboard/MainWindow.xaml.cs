using Castle.Facilities.TypedFactory;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Scenarios.Storyboard.ViewModels;
using System;
using System.Linq;
using System.Reflection;
using System.Windows;

namespace Scenarios.Storyboard
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IWindsorContainer _container;

      public MainWindow()
        {
            BootstrapContainer();
            InitializeComponent();
            DataContext = _container.Resolve<MainWindowViewModel>();
        }

        /// <summary>
        /// Initialise the Inversion of Control container and register all
        /// applicable services.
        /// </summary>
        private void BootstrapContainer()
        {
            _container = new WindsorContainer();
            _container.AddFacility<TypedFactoryFacility>();
            _container.Install(GetWindsorInstallers());
        }

        /// <summary>
        /// Finds all IWindsorInstaller types in the current assembly, 
        /// instantiating them once each, returning an array.
        /// </summary>
        /// <returns>
        /// An array of one object for each IWindsorInstaller implementation
        /// in the current assembly.
        /// </returns>
        private static IWindsorInstaller[] GetWindsorInstallers()
            => Assembly.GetCallingAssembly()
                        .GetTypes()
                        .Where(type => type.GetInterfaces()
                                           .Contains(typeof(IWindsorInstaller)))
                        .Select(type => (IWindsorInstaller)Activator.CreateInstance((type)))
                        .ToArray();
    }
}
