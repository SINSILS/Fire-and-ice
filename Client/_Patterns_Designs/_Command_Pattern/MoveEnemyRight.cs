using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client._Classes;

namespace Client._Patterns_Designs._Command_Pattern
{
    public class MoveEnemyRight : ICommand
    {
        //enemy info movement
        private int speed;
        private PictureBox enemyBox;

        // constructor
        public MoveEnemyRight(int speed, PictureBox enemyBox)
        {
            this.speed = speed;
            this.enemyBox = enemyBox;
        }

        public override void Execute()
        {
            enemyBox.Left -= speed;
        }

        public override void Undo()
        {
            enemyBox.Left += speed;
        }
    }
}
