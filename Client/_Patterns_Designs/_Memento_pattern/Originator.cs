using Client._Patterns_Designs._Template_Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client._Patterns_Designs._Memento_pattern
{
    public class Originator
    {
        private LabelUpdater textLine;

        public Originator()
        {

        }

        public void setLine(LabelUpdater textLine)
        {
            this.textLine = textLine;
        }

        public LabelUpdater getLine()
        {
            return this.textLine;
        }

        public Memento save()
        {
            return new Memento(textLine);
        }

        public void restore(Memento m)
        {
            this.textLine = m.getState();
        }

    }
}
