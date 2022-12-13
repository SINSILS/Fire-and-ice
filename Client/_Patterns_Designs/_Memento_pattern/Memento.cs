using Client._Patterns_Designs._Template_Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client._Patterns_Designs._Memento_pattern
{
    public class Memento
    {

        private LabelUpdater state;

        public Memento(LabelUpdater state)
        {
            this.state = state;
        }

        public LabelUpdater getState()
        {
            return this.state;
        }

        public void setState(LabelUpdater state)
        {
            this.state = state;
        }


    }
}
