using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWP_Lesson.Cortana.Views;
using UWP_Lesson.Services;
using UWP_Lesson.Views;

namespace UWP_Lesson.ViewModels
{
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            if (ViewModelBase.IsInDesignModeStatic)
            {
                // Create design time view services and models
            }
            else
            {
                // Create run time view services and models
            }

            //Register your services used here
            SetupNavigation();
            SetupInjection();

            SimpleIoc.Default.Register<BlankPageViewModel>();
            SimpleIoc.Default.Register<OtherPageViewModel>();
        }

        private void SetupNavigation()
        {
            SimpleIoc.Default.Register<INavigationService>(() =>
            {
                var navigationService = new NavigationService();
                navigationService.Configure("BlankPage", typeof(BlankPage));
                navigationService.Configure("OtherPage", typeof(OtherPage));
                navigationService.Configure("CortanaView", typeof(CortanaView));
                return navigationService;
            });
        }

        private void SetupInjection()
        {
            SimpleIoc.Default.Register<MyService>(() =>
            {
                return new MyService();
            });
            SimpleIoc.Default.Register<DatabaseService>(() =>
            {
                return new DatabaseService();
            });
        }

        public BlankPageViewModel BlankPageInstance
        {
            get { return ServiceLocator.Current.GetInstance<BlankPageViewModel>(); }
        }
        
        public OtherPageViewModel OtherPageInstance
        {
            get { return ServiceLocator.Current.GetInstance<OtherPageViewModel>(); }
        }
        
        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
}
}
