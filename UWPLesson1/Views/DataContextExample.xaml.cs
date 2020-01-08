using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using UWPLesson1.Entities;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Pour plus d'informations sur le modèle d'élément Page vierge, consultez la page https://go.microsoft.com/fwlink/?LinkId=234238

namespace UWPLesson1.Views
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class DataContextExample : Page
    {
        public User User { get; set; }

        public DataContextExample()
        {
            this.InitializeComponent();
            this.User = new User();
            //this.User = new User() { Firstname = "jean", Lastname = "Michel" };
            this.DataContext = this.User;

            this.Loaded += DataContextExample_Loaded;
        }

        private void DataContextExample_Loaded(object sender, RoutedEventArgs e)
        {
            this.User.Firstname = "jean";
            this.User.Lastname = "Michel";

            this.DataContext = this.User;
        }
    }
}
