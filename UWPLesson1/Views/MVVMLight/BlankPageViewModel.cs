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
using UWPLesson1.Entities;

namespace UWPLesson1.Views.MVVMLight
{
    public class BlankPageViewModel : ViewModelBase
    {
        private INavigationService navigationService;

        public User User { get; set; }
        public string ButtonContent { get; set; }
        public ICommand ButtonClick => new RelayCommand(() =>
                                     {
                                         this.navigationService.NavigateTo("OtherPage");
                                         MessengerInstance.Send<NotificationMessage<User>>(
              new NotificationMessage<User>(this.User, "User from BlankPage"), "BlankPageUserSender");
                                     });

        public BlankPageViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;
            this.User = new User() { Firstname = "John", Lastname = "Connord" };
            this.ButtonContent = "change";
        }
    }
}
