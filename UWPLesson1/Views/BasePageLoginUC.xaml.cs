using System;
using System.Collections.Generic;
using System.Diagnostics;
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

// Pour en savoir plus sur le modèle d'élément Contrôle utilisateur, consultez la page https://go.microsoft.com/fwlink/?LinkId=234236

namespace UWPLesson1.Views
{
    public sealed partial class BasePageLoginUC : UserControl
    {
        public BasePageLoginUC()
        {
            this.InitializeComponent();
            this.btnConnexion.Click += BtnConnexion_Click;
            this.hellButton.PointerEntered += HellButton_PointerEntered;
        }

        private void HellButton_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            Grid.SetColumn(this.hellButton, Grid.GetColumn(this.hellButton) + 1);
            this.hellButton.UpdateLayout();
            this.contentGrid.UpdateLayout();
        }

        private void BtnConnexion_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine(this.inputLogin.Text);
            Debug.WriteLine(this.inputPassword.Password);
            this.txtBTitle.FontSize = this.txtBTitle.FontSize * 1.5;
        }
    }
}
