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

// Pour en savoir plus sur le modèle d'élément Contrôle utilisateur, consultez la page https://go.microsoft.com/fwlink/?LinkId=234236

namespace UWP_Lesson.CustomControls
{
    public sealed partial class CustomTextBox : UserControl
    {
        public CustomTextBox()
        {
            this.InitializeComponent();
            this.TextBox.TextChanged += TextBox_TextChanged;
            // TODO add controls events
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            // TODO controls
        }

        private void TextBox_Loaded(object sender, RoutedEventArgs e)
        {
            this.ColorBorderStoryBoard.Begin();
        }
    }
}
