using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using static UWPTP3.Views.MvvmLight.ViewModelLocator;

namespace UWPTP3.Views.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private INavigationService navigationService;

        public String Btn1Text { get { return Pages.RoleCheckPage.ToString(); } }
        public String Btn2Text { get { return Pages.UserCheckPage.ToString(); } }
        public String Btn3Text { get { return Pages.UserAdvanceCheckPage.ToString(); } }

        public ICommand Btn1Command
        {
            get
            {
                return new RelayCommand(() => 
                {
                    this.navigationService.NavigateTo(Pages.RoleCheckPage.ToString());
                });
            }
        }

        public ICommand Btn2Command
        {
            get
            {
                return new RelayCommand(() =>
                {
                    this.navigationService.NavigateTo(Pages.UserCheckPage.ToString());
                });
            }
        }

        public ICommand Btn3Command
        {
            get
            {
                return new RelayCommand(() =>
                {
                    this.navigationService.NavigateTo(Pages.UserAdvanceCheckPage.ToString());
                });
            }
        }

        public MainPageViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;
        }
    }
}
