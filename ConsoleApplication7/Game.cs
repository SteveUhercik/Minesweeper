using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ConsoleApplication7
{
    class Game : Grid
    {

        private Tile[,] lowerTilesField;
        private Button[,] upperTilesField;
        private int fieldWidth;
        private int fieldHeight;
        private int numberOfMines;


        public Game(int fieldWidth, int fieldHeight, int numberOfMines)
        {
            this.ShowGridLines = false ;
            createRowsAndColumns();
            this.fieldWidth = fieldWidth;
            this.fieldHeight = fieldHeight;
            this.numberOfMines = numberOfMines;

            this.lowerTilesField = new Tile[fieldWidth, fieldHeight];
            this.createRowsAndColumns();
            this.generateMines();
            this.generateNumbers();
            this.addLowerTilesToTheGrid();
        }


        private void createRowsAndColumns()
        {
            for (int i = 0; i < fieldWidth; i++)
            {
                this.ColumnDefinitions.Add(new ColumnDefinition()
                {
                    Width = new GridLength(20)
                });
                
            }

            for(int i=0;i<fieldHeight;i++){
                this.RowDefinitions.Add(new RowDefinition()
                {
                    Height = new GridLength(20)
                });
            }

        }

        private void generateMines()
        {
            Random rand = new Random();
            int i = 0;
            while (i < numberOfMines)
            {
                int xPosition = rand.Next(fieldWidth);
                int yPosition = rand.Next(fieldHeight);
                if (lowerTilesField[xPosition, yPosition] == null)
                {
                    lowerTilesField[xPosition, yPosition] = new Tile(true, 0);                   
                    i++;
                }
            }
        }

        private void generateNumbers()
        {
            for (int y = 0; y < fieldHeight; y++)
            {
                for (int x = 0; x < fieldWidth; x++)
                {
                    if (lowerTilesField[x, y] == null)
                    {
                        lowerTilesField[x, y] = new Tile(false, countSurroundingMines(x, y));
                    }
                }
            }
        }

        private int countSurroundingMines(int xPosition, int yPosition)
        {
            int topBorder = -1, bottomBorder = 1, leftBorder = -1, rightBorder = 1;

            if (xPosition == 0) leftBorder = 0;
            if (xPosition == fieldWidth - 1) rightBorder = 0;
            if (yPosition == 0) topBorder = 0;
            if (yPosition == fieldHeight - 1) bottomBorder = 0;


            int totalCount = 0;
            for (int y = topBorder; y <= bottomBorder; y++)
            {
                for (int x = leftBorder; x <= rightBorder; x++)
                {
                    int tempX = xPosition + x;
                    int tempY = yPosition + y;
                    if ((lowerTilesField[tempX, tempY] != null) && !((x == 0) && (y == 0)))
                    {
                        if (lowerTilesField[tempX, tempY].IsMine) totalCount++;
                    }
                }
            }

            return totalCount;
        }

        private void addLowerTilesToTheGrid()
        {
            for (int xPosition = 0; xPosition < fieldWidth; xPosition++)
            {
                for (int yPosition = 0; yPosition < fieldHeight; yPosition++)
                {
                    this.Children.Add(lowerTilesField[xPosition, yPosition]);
                    Grid.SetColumn(lowerTilesField[xPosition, yPosition], xPosition);
                    Grid.SetRow(lowerTilesField[xPosition, yPosition], yPosition);
                }
            }
                
        }

    }


    

}
