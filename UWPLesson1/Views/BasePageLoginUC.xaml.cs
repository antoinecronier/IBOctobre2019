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
            this.Loaded += BasePageLoginUC_Loaded;
            this.btnConnexion.Click += BtnConnexion_Click;
            this.hellButton.PointerEntered += HellButton_PointerEntered;
            this.comboBoxByCode.SelectionChanged += ComboBoxByCode_SelectionChanged;
        }

        private List<Object> comboboxSelectedItems = new List<object>();
        private void ComboBoxByCode_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            comboboxSelectedItems.AddRange(e.AddedItems);
            foreach (var item in e.RemovedItems)
            {
                comboboxSelectedItems.Remove(item);
            }

            foreach (var item in comboboxSelectedItems)
            {
                Debug.WriteLine(item);
            }

            Debug.WriteLine(this.comboBoxByCode.SelectedItem);
        }

        private void BasePageLoginUC_Loaded(object sender, RoutedEventArgs e)
        {
            var resources = new Windows.ApplicationModel.Resources.ResourceLoader("MyStrings");
            this.inputLogin.Text = resources.GetString("Welcome");

            this.myTextBox.TextBox.Text = "test";

            this.comboBoxByCode.ItemsSource = new List<String> {"a","b","c"};
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
