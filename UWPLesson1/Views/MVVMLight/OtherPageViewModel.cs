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
using Windows.UI.Xaml.Navigation;

namespace UWPLesson1.Views.MVVMLight
{
    public class OtherPageViewModel : ViewModelBase
    {
        private INavigationService navigationService;

        public User User { get; set; }
        public string ButtonContent { get; set; }
        public ICommand ButtonClick => new RelayCommand(() =>
        {
            this.navigationService.NavigateTo("BlankPage");
            //this.navigationService.GoBack();
            //this.User.Firstname = "test";
            //this.User.Lastname = "1";
        });

        public OtherPageViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;
            this.User = new User() { Firstname = "Jean", Lastname = "Michel" };
            this.ButtonContent = "change";
            MessengerInstance.Register<NotificationMessage<User>>(this, "BlankPageUserSender", BlankPageUserRetriever);
        }

        private void BlankPageUserRetriever(NotificationMessage<User> obj)
        {
            this.User.CopyFrom(obj.Content as User);
        }
    }
}
