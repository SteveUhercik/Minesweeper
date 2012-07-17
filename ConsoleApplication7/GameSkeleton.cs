using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace ConsoleApplication7
{
    class GameSkeleton:Window
    {
        public GameSkeleton()
        {
            Grid grid = new Grid();
            grid.Width = 300;
            grid.Height = 300;
            grid.ShowGridLines = true;

            for (int i = 0; i < 3; i++)
            {
                int columnLenght;

                if (i == 1) columnLenght = 200;
                else columnLenght = 50;

                grid.ColumnDefinitions.Add(new ColumnDefinition()
                {
                    Width = new GridLength(columnLenght)
                });
                grid.RowDefinitions.Add(new RowDefinition()
                {
                    Height = new GridLength(columnLenght)
                });

            }

            Game game = new Game(10,10,10);
            grid.Children.Add(game);
            Grid.SetColumn(game, 1);
            Grid.SetRow(game, 1);

            //this.Content = new RectangleWithNumber();
            this.Content = grid;
            this.SizeToContent = SizeToContent.WidthAndHeight;
            this.ResizeMode = ResizeMode.NoResize;

        }


    }

}
