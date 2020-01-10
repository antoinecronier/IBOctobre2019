using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Views;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UWP_Lesson.Models;
using UWP_Lesson.Services;
using Windows.Globalization.DateTimeFormatting;
using Windows.Storage;
using Windows.UI.Xaml.Navigation;

namespace UWP_Lesson.ViewModels
{
    public class OtherPageViewModel : ViewModelBase, INavigationEvent
    {
        public String Field1 { get; set; }
        public String Field2 { get; set; }

        private INavigationService navigationService;
        private MyService myService;

        public String Field3 { get { return myService.MyIncrementalInt.ToString(); } }
        public ObservableCollection<Class1> Class1s { get; set; }

        private DatabaseService databaseService;

        public ICommand NavigationCommand
        {
            get {
                return new RelayCommand(() =>
                {
                    navigationService.NavigateTo("BlankPage");
                });
            }
        }

        public ICommand MessageSender
        {
            get
            {
                return new RelayCommand(() =>
                {
                    MessengerInstance.Send<NotificationMessage<String>>(new NotificationMessage<string>(Field3,"Event from OtherPageViewModel"),"Field3Update");
                });
            }
        }

        public ICommand SaveFile
        {
            get
            {
                return new RelayCommand(async () =>
                {
                    StorageFolder localFolder = ApplicationData.Current.LocalFolder;
                    StorageFile myFile = await localFolder.CreateFileAsync("myFile.txt",
                        CreationCollisionOption.OpenIfExists);
                    await FileIO.AppendTextAsync(myFile, this.Field1 + "." + this.Field2);
                });
            }
        }

        public ICommand LoadFile
        {
            get
            {
                return new RelayCommand(async () =>
                {
                    StorageFolder localFolder = ApplicationData.Current.LocalFolder;
                    StorageFile myFile = await localFolder.GetFileAsync("myFile.txt");
                    String data = await FileIO.ReadTextAsync(myFile);
                    String[] datas = data.Split('.');
                    Field1 = datas[0];
                    Field2 = datas[1];
                });
            }
        }

        public ICommand SaveToDb
        {
            get
            {
                return new RelayCommand(async () =>
                {
                    Class1 c11 = new Class1() { Field1 = "testF11", Field2 = "testF21", Field3 = "TestF31" };
                    this.databaseService.Save(c11);

                    Class2A class2A = new Class2A();
                    class2A.Data = "my data";
                    class2A.MyDate = DateTime.Now;
                    Class2A class2ASub = new Class2A();
                    class2ASub.Data = "sub data";
                    class2A.SubClassA = class2ASub;
                    List<Class2B> class2Bs = new List<Class2B>();
                    class2Bs.Add(new Class2B() { Data = "2B data 1" });
                    class2Bs.Add(new Class2B() { Data = "2B data 2" });
                    class2Bs.Add(new Class2B() { Data = "2B data 3" });
                    class2A.ListClass2B = class2Bs;

                    this.databaseService.SaveWithChildren(class2A);
                });
            }
        }

        public ICommand LoadFromDb
        {
            get
            {
                return new RelayCommand(async () =>
                {
                    Class1s.Clear();

                    foreach (Class1 item in this.databaseService.Class1)
                    {
                        Class1s.Add(item);
                    }

                    List<Class2A> li = this.databaseService.Class2AEager;

                    WebServiceManager<Post> postManager = new WebServiceManager<Post>("https://jsonplaceholder.typicode.com/");
                    List<Post> posts = await postManager.Get();
                    Post post = await postManager.Get(10);
                    Post putPost = new Post() { body="testbody", title="testtitle", userId=2 };
                    Post resultPutPost = await postManager.Put(putPost);
                    Post deletePost = new Post() { Id=2 };
                    Post resultDeletePost = await postManager.Delete(deletePost);
                });
            }
        }

        public OtherPageViewModel(INavigationService navigationService, MyService myService, DatabaseService databaseService)
        {
            this.Field1 = "Field1";
            this.Field2 = "Field2";
            this.navigationService = navigationService;
            this.myService = myService;
            this.Class1s = new ObservableCollection<Class1>();
            this.databaseService = databaseService;
        }

        public void OnNavigatedTo(NavigationEventArgs e)
        {
            Debug.WriteLine("Enter OtherPage");
        }

        public void OnNavigatedFrom(NavigationEventArgs e)
        {
            Debug.WriteLine("Leave OtherPage");
        }
    }
}
