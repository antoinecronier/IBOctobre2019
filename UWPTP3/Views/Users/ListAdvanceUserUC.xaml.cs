﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using UWPTP3.Entities;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Pour en savoir plus sur le modèle d'élément Contrôle utilisateur, consultez la page https://go.microsoft.com/fwlink/?LinkId=234236

namespace UWPTP3.Views.Users
{
    public sealed partial class ListAdvanceUserUC : UserControl
    {
        public ObservableCollection<User> UserList { get; set; }

        public ListAdvanceUserUC()
        {
            this.InitializeComponent();
            this.UserList = new ObservableCollection<User>();
            this.DataContext = UserList;
        }

        private void MenuFlyoutDelete_Click(object sender, RoutedEventArgs e)
        {
            this.UserList.Remove(sender as User);
        }
    }
}
