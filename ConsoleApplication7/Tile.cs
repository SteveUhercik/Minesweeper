using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;


namespace ConsoleApplication7
{
    class Tile:Canvas
    {

        public bool IsMine { get; set; }
        public int Number;

        public Tile(bool isMine,int number)
        {
            this.Width = 20;
            this.Height = 20;
            this.IsMine = isMine;
            this.Number = number;

            createRectangle();
            if (this.IsMine) createMine();
            else createNumber(number);
            createButton();
        }

        private void createRectangle()
        {
            Rectangle rect = new Rectangle()
            {
                Width = this.Width,
                Height = this.Height,
                Fill = Brushes.LightGray,
                Stroke = Brushes.Black,
                StrokeThickness = 1
            };
            this.Children.Add(rect);
            Canvas.SetLeft(rect, 0);
            Canvas.SetTop(rect, 0);

            

        }

        private void createNumber(int number)
        {
            Brush brush = Brushes.White;
            switch (number)
            {
                case 1: brush = Brushes.Blue;
                    break;
                case 2: brush = Brushes.Green;
                    break;
                case 3: brush = Brushes.Red;
                    break;
                case 4: brush = Brushes.DarkBlue;
                    break;
                default: brush = Brushes.Brown;
                    break;
            }

            TextBlock text = new TextBlock();
            text.FontSize = 15;

            text.Foreground = brush;

            if(number!=0) text.Text = number.ToString();
            this.Children.Add(text);
            Canvas.SetLeft(text, 6);
            Canvas.SetTop(text, 0);
        }


        private void createMine()
        {
            TextBlock text = new TextBlock();
            text.FontSize = 15;

            text.Foreground = Brushes.Black;

            text.Text = "@";
            this.Children.Add(text);
            Canvas.SetLeft(text, 6);
            Canvas.SetTop(text, 0);
        }

        private void createButton()
        {
            Button b = new Button()
            {
                Width = 20,
                Height = 20,
            };
            b.Click += onClick;
            this.Children.Add(b);
        }

        private void onClick(object sender, RoutedEventArgs a)
        {
            Button b = sender as Button;
            this.Children.Remove(b);
        }



    }
}
