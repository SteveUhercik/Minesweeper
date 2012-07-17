using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication7
{
    class MainApplication
    {
        private MineOrNumber[,] minesField;
        private bool[,] resultField;
        private int numberOfMines;
        private int fieldWidth;
        private int fieldHeight;

        public MainApplication(int fieldWidth, int fieldHeight, int numberOfMines)
        {
            this.fieldWidth = fieldWidth;
            this.fieldHeight = fieldHeight;
            this.numberOfMines = numberOfMines;
            minesField = new MineOrNumber[fieldWidth, fieldHeight];
            resultField = new bool[fieldWidth, fieldHeight];
        }

        public void generateMines()
        {
            Random rand = new Random();
            int i =0;
            while (i < this.numberOfMines)
            {
                int xPosition = rand.Next(fieldWidth);
                int yPosition = rand.Next(fieldHeight);
                if (this.minesField[xPosition, yPosition] != null) ; //do nothing, because this position is taken, another mine must be generated
                else
                {
                    this.minesField[xPosition, yPosition] = new MineOrNumber(true, 0);
                    i++;
                }
            }
            generateNumbers();
        }

        private void generateNumbers()
        {
            for (int y = 0; y < fieldHeight; y++)
            {
                for (int x = 0; x < fieldWidth; x++)
                {
                    if (minesField[x,y] == null)
                    {
                        minesField[x,y] = new MineOrNumber(false, countSurroundingMines(x,y));
                    }
                }
            }
        }

        private int countSurroundingMines(int xPosition, int yPosition)
        {
            int topBorder=-1, bottomBorder=1, leftBorder=-1, rightBorder=1;

            if (xPosition == 0) leftBorder = 0;
            if (xPosition == fieldWidth - 1) rightBorder = 0;
            if (yPosition == 0) topBorder = 0;
            if (yPosition == fieldHeight - 1) bottomBorder = 0;


            int totalCount = 0;
            for (int y = topBorder; y <= bottomBorder; y++ )
            {
                for (int x = leftBorder; x <= rightBorder; x++ )
                {
                    int tempX = xPosition + x;
                    int tempY = yPosition + y;
                    if ((minesField[tempX,tempY] != null) && !((x == 0) && (y == 0)))
                    {
                        if (minesField[tempX,tempY].IsMine) totalCount++;
                    }
                }
            }

            return totalCount;
        }

        public void drawMinesField()
        {
            for (int i = 0; i < fieldWidth; i++)
            {
                for (int j = 0; j < fieldHeight; j++)
                {
                    Console.Write(minesField[i, j]);
                }
                Console.WriteLine(" ");
            }
        }


        public void drawResultField()
        {
            for (int i = 0; i < fieldWidth; i++)
            {
                for (int j = 0; j < fieldHeight; j++)
                {
                    if (resultField[i,j]) Console.Write(".");
                    else Console.Write("x");
                }
                Console.WriteLine(" ");
            }
        }


        public void makeStepOnThePosition(int xPosition, int yPosition)
        {
            if (minesField[xPosition, yPosition].IsMine) exposeAllTheMines();
            else
            {
                resultField[xPosition,yPosition] = true;
                if(minesField[xPosition,yPosition].Number == 0) exposeSurroundingPositions(xPosition,yPosition);
            }
        }

        private void exposeAllTheMines()
        {
            for (int i = 0; i < fieldWidth; i++)
            {
                for (int j = 0; j < fieldHeight; j++)
                {
                    
                }
            }

        }

        private void exposeSurroundingPositions(int xPosition,int yPosition)
        {
            int topBorder = -1, bottomBorder = 1, leftBorder = -1, rightBorder = 1;

            if (xPosition == 0) leftBorder = 0;
            if (xPosition == fieldWidth - 1) rightBorder = 0;
            if (yPosition == 0) topBorder = 0;
            if (yPosition == fieldHeight - 1) bottomBorder = 0;

            for (int y = topBorder; y <= bottomBorder; y++)
            {
                for (int x = leftBorder; x <= rightBorder; x++)
                {
                    int tempX = xPosition + x;
                    int tempY = yPosition + y;
                    if ((minesField[tempX, tempY].Number == 0)&&(resultField[tempX,tempY]==false))
                    {
                        resultField[tempX, tempY] = true;
                        exposeSurroundingPositions(tempX, tempY);
                    }
                    else resultField[tempX, tempY] = true;

                }
            }
        }

        public void initializeResultField()
        {
            for (int i = 0; i < fieldWidth; i++)
            {
                for (int j = 0; j < fieldHeight; j++)
                {
                    resultField[i, j] = false;
                }
            }
        }
      

    }
}
