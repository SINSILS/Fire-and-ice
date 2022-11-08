using Client._Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client._Patterns_Designs._Command_Pattern
{
    public class MoveEnemyLeft : ICommand
    {
        private int speed;
        private PictureBox enemyBox;

        public MoveEnemyLeft(int speed, PictureBox enemyBox)
        {
            this.speed = speed;
            this.enemyBox = enemyBox;
        }

        public override void Execute()
        {
            enemyBox.Left += speed;
        }

        public override void Undo()
        {
            enemyBox.Left -= speed;
        }
    }
}
