using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            this.DataContext = this.User;

            this.Loaded += DataContextExample_Loaded;
            this.btn1.Click += Btn1_Click;
            this.btn2.Click += Btn2_Click;
        }

        private void Btn2_Click(object sender, RoutedEventArgs e)
        {
            this.User.Firstname = "jean";
            this.User.Lastname = "Michel";
            this.UpdateLayout();
        }

        private void Btn1_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine(this.User.FullName);
        }

        private void DataContextExample_Loaded(object sender, RoutedEventArgs e)
        {
        }
    }
}
