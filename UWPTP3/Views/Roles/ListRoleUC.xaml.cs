using System;
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

namespace UWPTP3.Views.Roles
{
    public sealed partial class ListRoleUC : UserControlBase
    {
        public ObservableCollection<Role> RoleList { get; set; }

        public ListRoleUC()
        {
            this.InitializeComponent();
            this.RoleList = new ObservableCollection<Role>();
            this.DataContext = RoleList;
        }

        private void MenuFlyoutDelete_Click(object sender, RoutedEventArgs e)
        {
            this.RoleList.Remove(sender as Role);
        }
    }
}
