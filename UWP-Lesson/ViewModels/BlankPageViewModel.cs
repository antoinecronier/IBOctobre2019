using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace UWP_Lesson.ViewModels
{
    public class BlankPageViewModel : ViewModelBase
    {
        public String Firstname { get; set; }
        public String Lastname { get; set; }
        public String Surname { get; set; }

        private INavigationService navigationService;

        public ICommand NavigationCommand { get; set; }

        public ICommand NavigationCortana
        {
            get
            {
                return new RelayCommand(() =>
                {
                    navigationService.NavigateTo("CortanaView");
                });
            }
        }

        public BlankPageViewModel(INavigationService navigationService)
        {
            this.Firstname = "john";
            this.Lastname = "Connord";
            this.Surname = "johny";
            this.navigationService = navigationService;

            NavigationCommand = new RelayCommand(() =>
            {
                navigationService.NavigateTo("OtherPage");
            });

            MessengerInstance.Register<NotificationMessage<String>>(this, "Field3Update", NotifyMe);
        }

        public void NotifyMe(NotificationMessage<String> notificationMessage)
        {
            string notification = notificationMessage.Notification;
            this.Surname = notificationMessage.Content;
        }


    }
}
