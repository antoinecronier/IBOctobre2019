using System;
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
    public sealed partial class UserAdvanceCheckPage : Page
    {
        public UserAdvanceCheckPage()
        {
            this.InitializeComponent();
            this.userEdit.btnValider.Click += BtnValider_Click;
            this.userList.listView.SelectionChanged += ListView_SelectionChanged;
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                //this.roleShow.Role = e.AddedItems.ElementAt(0) as Role;
                User user = e.AddedItems.ElementAt(0) as User;
                this.userShow.User.CopyFrom(user);
                this.userShow.roleUc.Role.CopyFrom(user.Role);
            }
        }

        private void BtnValider_Click(object sender, RoutedEventArgs e)
        {
            User user = this.userEdit.User.Copy() as User;
            user.Role = this.userEdit.roleUc.Role.Copy() as Role;
            this.userList.UserList.Add(user);
        }
    }
}
