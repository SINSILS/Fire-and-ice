using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client._Classes
{
    public class Enemy
    {
        public int Speed { get; set; }
        public int Damage { get; }

        public Enemy(int speed)
        {
            this.Speed=speed;
            Damage = 1;
        }
    }
}
