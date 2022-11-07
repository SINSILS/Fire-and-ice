using Client._Patterns_Designs._Decorator_Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client._Classes
{
    public class Platform : IPlatform
    {
        public Color PlatformColor { get; set; } = Color.White;
        public int XPos { get; set; } = 0;
        public int YPos { get; set; }=0;
        public PictureBox Picture { get; set; }= new PictureBox();
        public int Speed { get; set; } = 0;

        int IPlatform.Speed => Speed;

        public Platform(Color platformColor, int xPos, int yPos, PictureBox picture,int speed)
        {
            Picture.BackColor=platformColor;
            Picture.Location= new Point(xPos, yPos);
            Picture=picture;
        }

        public Platform(PictureBox picture)
        {
            Picture=picture;
        }

        public Platform()
        {

        }

        public IPlatform CreatePlatform()
        {
            Picture.BackColor=Color.Red;
            return this;
        }
    }
}
