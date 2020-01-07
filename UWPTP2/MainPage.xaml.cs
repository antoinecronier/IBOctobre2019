using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Pour plus d'informations sur le modèle d'élément Page vierge, consultez la page https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UWPTP2
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private Button btn;
        private Boolean waitDialog = true;

        public MainPage()
        {
            this.InitializeComponent();
            this.Loaded += MainPage_Loaded;
        }

        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            Random rand = new Random();
            for (int i = 1; i < rand.Next(10,1000); i++)
            {
                this.mainGrid.RowDefinitions.Add(new RowDefinition());
            }
            for (int i = 1; i < rand.Next(10, 1000); i++)
            {
                this.mainGrid.ColumnDefinitions.Add(new ColumnDefinition());
            }

            btn = new Button();
            Grid.SetRow(btn, rand.Next(0, this.mainGrid.RowDefinitions.Count - 1));
            Grid.SetColumn(btn, rand.Next(0, this.mainGrid.ColumnDefinitions.Count - 1));
            btn.HorizontalAlignment = HorizontalAlignment.Stretch;
            btn.VerticalAlignment = VerticalAlignment.Stretch;

            btn.PointerEntered += Btn_PointerEntered;
            btn.LayoutUpdated += Btn_LayoutUpdated;

            this.mainGrid.Children.Add(btn);
        }

        private void Btn_LayoutUpdated(object sender, object e)
        {
            int column = Grid.GetColumn(btn);
            int row = Grid.GetRow(btn);

            Debug.WriteLine("Button new position is row {0} - column {1}", row, column);
            if (waitDialog 
                &&(
                (row % 9 == 0 && column % 9 == 0)
                ||
                (row % 7 == 0 && column % 7 == 0)
                //||
                //(row % 2 == 0 && column % 2 == 0)
                ))
            {
                waitDialog = false;
                ContentDialog dialog = new ContentDialog();
                dialog.Title = "Gagné";
                dialog.PrimaryButtonText = "Arréter";
                dialog.PrimaryButtonClick += Dialog_PrimaryButtonClick;
                dialog.SecondaryButtonText = "continuer";
                dialog.SecondaryButtonClick += Dialog_SecondaryButtonClick;
                dialog.ShowAsync();
            }
        }

        private void Dialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            waitDialog = true;
            MoveOnGrid();
        }

        private void Dialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            Application.Current.Exit();
        }

        private void Btn_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            MoveOnGrid();
        }

        private void MoveOnGrid()
        {
            int column = Grid.GetColumn(btn);
            int row = Grid.GetRow(btn);

            Random rand = new Random();
            int newRow = rand.Next(0, this.mainGrid.RowDefinitions.Count - 1);
            int newColumn = rand.Next(0, this.mainGrid.ColumnDefinitions.Count - 1);

            if (column != newColumn && row != newRow)
            {
                Grid.SetRow(btn, newRow);
                Grid.SetColumn(btn, newColumn);
                //btn.UpdateLayout();
                //this.mainGrid.UpdateLayout();
            }
            else
            {
                MoveOnGrid();
            }
        }
    }
}
