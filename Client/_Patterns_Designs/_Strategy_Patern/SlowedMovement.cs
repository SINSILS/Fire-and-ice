﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client._Classes;

namespace Client._Patterns_Designs._Strategy_Patern
{
    public class SlowedMovement : MoveAlgorithm
    {

        public override void DoMovement()
        {
            GamePlayer.jumpSpeed = -4;
            GamePlayer.playerSpeed = 2;
        }

    }
}
