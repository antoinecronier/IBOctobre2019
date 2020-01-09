using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWPLesson1.Views.MVVMLight
{
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            //Register your services used here
            SimpleIoc.Default.Register<INavigationService>(() =>
            {
                var navigationService = new NavigationService();
                navigationService.Configure("BlankPage", typeof(BlankPage));
                navigationService.Configure("OtherPage", typeof(OtherPage));
                return navigationService;
            });
            SimpleIoc.Default.Register<BlankPageViewModel>();
            SimpleIoc.Default.Register<OtherPageViewModel>();
        }

        public BlankPageViewModel BlankPageInstance
        {
            get { return ServiceLocator.Current.GetInstance<BlankPageViewModel>(); }
        }

        public OtherPageViewModel OtherPageInstance
        {
            get { return ServiceLocator.Current.GetInstance<OtherPageViewModel>(); }
        }
    }
}
