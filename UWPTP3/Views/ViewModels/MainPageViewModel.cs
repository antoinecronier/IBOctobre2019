using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UWPTP3.Entities;
using UWPTP3.Services;
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
                    WebServiceManagerTester();
                    //this.navigationService.NavigateTo(Pages.UserCheckPage.ToString());
                });
            }
        }

        private async void WebServiceManagerTester()
        {
            User user = new User() { Firstname = "jean", Lastname = "Michel", Role = new Role() { Name="role1" } };
            Debug.WriteLine(JsonConvert.SerializeObject(user));
            String json = "{\"Firstname\":\"jean\",\"Lastname\":\"Michel\",\"Role\":{\"Name\":\"role1\",\"Id\":0},\"RoleId\":0,\"Id\":0}";
            User serU = JsonConvert.DeserializeObject<User>(json);

            WebServiceManager<Post> postManager = new WebServiceManager<Post>("https://jsonplaceholder.typicode.com/");
            Post post1 = await postManager.Get(1);
            List<Post> posts = await postManager.Get();
            Post postPost = new Post() { body = "coucou", title = "test", userId = 1 };
            Post postPostResult = await postManager.Post(postPost);
            postPostResult.title = "toto";
            await postManager.Put(postPostResult);
            await postManager.Delete(postPostResult);
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
