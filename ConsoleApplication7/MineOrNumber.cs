using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication7
{
    class MineOrNumber
    {
        public int Number { get; set; }
        public bool IsMine { get; set; }

        public MineOrNumber(bool isMine, int number)
        {
            if (isMine) IsMine = true;
            else
            {
                IsMine = false;
                Number = number;
            }
        }

        public override string ToString()
        {
            if (this.IsMine) return "*";
            return this.Number.ToString();
        }

    }
}
