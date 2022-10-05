using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client._Classes
{
    public class Lever
    {
        public bool isPushed { get; set; }

        public Lever(bool isPushed)
        {
            this.isPushed=isPushed;
        }
    }
}
