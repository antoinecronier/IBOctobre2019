using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWPTP3.Views.ViewModels;

namespace UWPTP3.Views.MvvmLight
{
    public class ViewModelLocator
    {
        public enum Pages
        {
            UserAdvanceCheckPage,
            UserCheckPage,
            RoleCheckPage,
            MainPage
        }

        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            
            SimpleIoc.Default.Register<INavigationService>(() =>
            {
                var navigationService = new NavigationService();
                //navigationService.Configure(Pages.UserAdvanceCheckPage.ToString(), typeof(UserAdvanceCheckPage));
                //navigationService.Configure(Pages.UserCheckPage.ToString(), typeof(UserCheckPage));
                navigationService.Configure(Pages.RoleCheckPage.ToString(), typeof(RoleCheckPage));
                navigationService.Configure(Pages.MainPage.ToString(), typeof(MainPage));
                return navigationService;
            });
            //SimpleIoc.Default.Register<UserAdvanceCheckPageViewModel>();
            //SimpleIoc.Default.Register<UserCheckPageViewModel>();
            SimpleIoc.Default.Register<RoleCheckPageViewModel>();
            SimpleIoc.Default.Register<MainPageViewModel>();
        }

        //public UserAdvanceCheckPageViewModel UserAdvanceCheckPageInstance
        //{
        //    get { return ServiceLocator.Current.GetInstance<UserAdvanceCheckPageViewModel>(); }
        //}

        //public UserCheckPageViewModel UserCheckPageInstance
        //{
        //    get { return ServiceLocator.Current.GetInstance<UserCheckPageViewModel>(); }
        //}

        public RoleCheckPageViewModel RoleCheckPageInstance
        {
            get { return ServiceLocator.Current.GetInstance<RoleCheckPageViewModel>(); }
        }

        public MainPageViewModel MainPageInstance
        {
            get { return ServiceLocator.Current.GetInstance<MainPageViewModel>(); }
        }
    }
}
