using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    //Singleton
    public class Score
    {
        private static Score instance = null;
        private static object threadLock = new object();
        public int value { get; set; }

        private Score() 
        {
            value = 0;
        }

        public static Score getInstance() 
        {
            lock(threadLock)
            {
                if(instance == null) 
                {
                    instance = new Score();
                }
                return instance;
            }
        }

        public void increaseScore(int x)
        {
            value = value + x;
        }
    }
}
