using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client._Classes
{
    public class Obstacle : ICloneable
    {
        public PictureBox pic { get; set; }
        public int Damage { get; set; }



        public Obstacle(PictureBox pic, int damage)
        {
            pic=pic;
            Damage=damage;
        }

        public object Clone()
        {
            return (Obstacle) MemberwiseClone();
        }

        public Obstacle DeepCopy()
        {
            Obstacle DeepCopyObstacle = new Obstacle(this.pic,
                                this.Damage);
            return DeepCopyObstacle;
        }
    }
}
