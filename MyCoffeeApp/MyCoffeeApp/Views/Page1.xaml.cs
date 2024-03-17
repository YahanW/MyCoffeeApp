using MyCoffeeApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyCoffeeApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : ContentPage
    {
        public Page1()
        {
            InitializeComponent();
            //InitiateBoard();

            for (int row = 0; row < 9; row++)
            {
                for (int column = 0; column < 9; column++)
                {

                    BoxView border = new BoxView
                    {
                        Color = Color.White, // border color
                        HeightRequest = 0.1,   // Border thickness
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        VerticalOptions = LayoutOptions.FillAndExpand

                    };

                    Label label = new Label
                    {
                        Text = (row * 9 + column + 1).ToString(),
                        VerticalOptions = LayoutOptions.Center,
                        HorizontalOptions = LayoutOptions.Center,
                    };

                    // Add Border to Grid
                    sudokuGrid.Children.Add(border, column, row);
                    Grid.SetRowSpan(border, 1);
                    Grid.SetColumnSpan(border, 1);

                    // Add Label to Grid
                    sudokuGrid.Children.Add(label, column, row);
                    Grid.SetRowSpan(label, 1);
                    Grid.SetColumnSpan(label, 1);
                }
            }
        }
        public Board board;

        public void InitiateBoard()
        {

        }
    }
}