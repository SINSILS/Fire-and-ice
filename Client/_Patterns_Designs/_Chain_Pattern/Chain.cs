using Client._Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client._Patterns_Designs._Chain_Pattern
{
    public interface Chain
    {
        public void setNextChain(Chain nextChain);

        public void Interact(Control x, PictureBox player, GamePlayer playerStats);
    }
}
