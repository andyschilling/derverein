using System;
using DerVerein.Common;
using Microsoft.Practices.Unity;
using Prism.Mvvm;
using Prism.Regions;

namespace DerVerein.ViewModels
{
    public class ViewModelBase : BindableBase
    {
        public ViewModelBase(IUnityContainer container)
        {
            Container = container;
        }

        public string ApplicationName => "Der Verein";

        protected readonly IUnityContainer Container;

        protected void NavigateTo(Type viewType, string regionName)
        {
            var view = Container.Resolve(viewType);
            var regionManager = Container.Resolve<IRegionManager>();

            if (!regionManager.Regions[regionName].Views.Contains(view))
            {
                regionManager.Regions[regionName].Add(view);
            }

            regionManager.Regions[regionName].Activate(view);
        }
    }
}