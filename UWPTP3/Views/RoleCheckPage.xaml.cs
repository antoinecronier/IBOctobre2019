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

// Pour plus d'informations sur le modèle d'élément Page vierge, consultez la page https://go.microsoft.com/fwlink/?LinkId=234238

namespace UWPTP3.Views
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class RoleCheckPage : Page
    {
        public RoleCheckPage()
        {
            this.InitializeComponent();
            this.roleEdit.btnValider.Click += BtnValider_Click;
            this.roleList.listView.SelectionChanged += ListView_SelectionChanged;
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                //this.roleShow.Role = e.AddedItems.ElementAt(0) as Role;
                this.roleShow.Role.CopyFrom(e.AddedItems.ElementAt(0) as Role);
            }
        }

        private void BtnValider_Click(object sender, RoutedEventArgs e)
        {
            this.roleList.RoleList.Add(this.roleEdit.Role.Copy() as Role);
        }
    }
}
