using Client._Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client._Patterns_Designs._Chain_Pattern
{
    class VerticalInteraction : Chain
    {
        private Chain nextInChain;

        public void Interact(Control x, PictureBox player, GamePlayer playerStats)
        {
            if ((string)x.Tag == "Vertical")
            {
                if (player.Bounds.IntersectsWith(x.Bounds))
                {
                    playerStats.force = 8;
                    player.Top = x.Top - player.Height;
                    player.Left -= playerStats.horizontalSpeed;
                }

                x.BringToFront();
            }
            else
            {
                //nextInChain.Interact(x, player, playerStats);
                Console.WriteLine("Only works with platform movement");
            }
        }

        public void setNextChain(Chain nextChain)
        {
            this.nextInChain = nextChain;
        }
    }
}
