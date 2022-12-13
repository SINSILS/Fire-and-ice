using Client._Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client._Patterns_Designs._Chain_Pattern
{
    class PlatformInteraction : Chain
    {
        private Chain nextInChain;

        public void Interact(Control x, PictureBox player, GamePlayer playerStats)
        {
            if ((string)x.Tag == "platform")
            {
                if (player.Bounds.IntersectsWith(x.Bounds))
                {
                    playerStats.force = 8;
                    player.Top = x.Top - player.Height;


                    if ((string)x.Name == "horizontalPlatform" && playerStats.goLeft == false || (string)x.Name == "horizontalPlatform" && playerStats.goRight == false)
                    {
                        player.Left -= playerStats.horizontalSpeed;
                    }
                }

                x.BringToFront();
            }
            else
            {
                nextInChain.Interact(x, player, playerStats);
            }
        }

        public void setNextChain(Chain nextChain)
        {
            this.nextInChain = nextChain;
        }

    }
}
