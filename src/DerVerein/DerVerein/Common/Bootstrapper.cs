using System.Windows;
using DerVerein.ViewModels;
using DerVerein.Views;
using Microsoft.Practices.Unity;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Unity;

namespace DerVerein.Common
{
    public class Bootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            var shell = Container.Resolve<Shell>();

            return shell;
        }

        protected override void InitializeShell()
        {
            base.InitializeShell();

            var startView = Container.Resolve<StartView>();
            var regionManager = Container.Resolve<IRegionManager>();
            regionManager.Regions[RegionNames.MainRegion].Add(startView);
            regionManager.Regions[RegionNames.MainRegion].Activate(startView);

            Application.Current.MainWindow = (Window)Shell;
            Application.Current.MainWindow.Show();
        }

        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();

            ViewModelLocationProvider.SetDefaultViewModelFactory(type => Container.Resolve(type));
        }

        /*protected override void ConfigureServiceLocator()
        {
            base.ConfigureServiceLocator();

            Container.RegisterInstance(typeof(IDataStore), FileDataStore.GetInstance());
        }*/
    }
}