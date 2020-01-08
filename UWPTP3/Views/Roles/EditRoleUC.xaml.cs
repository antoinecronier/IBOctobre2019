using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using UWPTP3.Entities;

// Pour en savoir plus sur le modèle d'élément Contrôle utilisateur, consultez la page https://go.microsoft.com/fwlink/?LinkId=234236

namespace UWPTP3.Views.Roles
{
    public sealed partial class EditRoleUC : UserControlBase
    {
        private Role role;

        public Role Role
        {
            get { return role; }
            set { role = value;}
        }


        public EditRoleUC()
        {
            this.InitializeComponent();
            this.Role = new Role();
            this.DataContext = Role;
        }
    }
}
