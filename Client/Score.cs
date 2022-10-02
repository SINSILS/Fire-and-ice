using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    internal class Score
    {
        public int value { get; set; }

        public Score()
        {
            value = 0;
        }

        public void increaseScore(int x) 
        {
            value = value + x;
        }
    }
}
