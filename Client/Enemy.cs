﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class Enemy
    {
        public int speed { get; set; }

        public Enemy(int speed)
        {
            this.speed=speed;
        }
    }
}