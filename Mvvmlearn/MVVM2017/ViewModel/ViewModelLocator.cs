using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using MVVM2017.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM2017.ViewModel
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            //if (ViewModelBase.IsInDesignModeStatic)
            //{
            //    // Create design time view services and models
            //   // SimpleIoc.Default.Register<IDataService, DesignDataService>();
            //}
            //else
            //{
            //    // Create run time view services and models
            //   // SimpleIoc.Default.Register<IDataService, DataService>();
            //}
            var navigationService = this.CreateNavigationService();
            SimpleIoc.Default.Register<INavigationService>(() => navigationService);
            //SimpleIoc.Default.Register<INavigationService, NavigationService>();
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<PageTwoViewModel>();

        }
        private INavigationService CreateNavigationService()
        {
            var navigationService = new NavigationService();
            navigationService.Configure("MainPage", typeof(MainPage));
            navigationService.Configure("PageTwo", typeof(PageTwo));
            return navigationService;
        }
        public MainViewModel MainPageInstance
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }
        public PageTwoViewModel PageTwoInstance
        {
            get
            {
                return ServiceLocator.Current.GetInstance<PageTwoViewModel>();
            }
        }
        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}
