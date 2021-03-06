﻿using System;
using System.Collections.Generic;
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
    public sealed partial class EditAdvanceUserUC : UserControl
    {
        public User User { get; set; }

        public EditAdvanceUserUC()
        {
            this.InitializeComponent();
            this.User = new User();
            this.DataContext = this.User;
            if (this.User.Role != null)
            {
                this.roleUc.Role.CopyFrom(this.User.Role);
            }
            
            this.Loaded += EditAdvanceUserUC_Loaded;
        }

        private void EditAdvanceUserUC_Loaded(object sender, RoutedEventArgs e)
        {
            this.roleUc.btnValider.Visibility = Visibility.Collapsed;
        }
    }
}
