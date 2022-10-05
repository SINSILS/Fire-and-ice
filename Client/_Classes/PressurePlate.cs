using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client._Classes
{
    public class PressurePlate
    {
        public bool IsPressed { get; set; }

        public PressurePlate(bool isPressed)
        {
            this.IsPressed=isPressed;
        }
    }
}
