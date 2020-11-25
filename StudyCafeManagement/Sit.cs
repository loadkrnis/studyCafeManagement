using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyCafeManagement
{
    public class Sit
    {
        public int x;
        public int y;
        public char isUsed;
        public Sit(int x, int y, char isUsed)
        {
            this.x = x;
            this.y = y;
            this.isUsed = isUsed;
        }
    }
}
