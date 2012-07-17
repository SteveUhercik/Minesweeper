using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace ConsoleApplication7
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            
            //Window win = new Window();
            GameSkeleton win = new GameSkeleton();

            Application app = new Application();
            app.Run(win);
            

            /*
            MainApplication app = new MainApplication(10,10,20);
            
            app.generateMines();
            app.drawMinesField();
            app.makeStepOnThePosition(1, 1);
            app.drawResultField();
          */

        }
    }
}
