namespace Client._Classes
{
    public class Obstacle : ICloneable
    {
        public PictureBox pic { get; set; }
        public int Damage { get; set; }

        public Obstacle(PictureBox pic, int damage)
        {
            this.pic = pic;
            Damage = damage;
        }

        public object Clone()
        {
            return (Obstacle)MemberwiseClone();
        }

        public Obstacle DeepCopy()
        {
            Obstacle DeepCopyObstacle = new Obstacle(this.pic, this.Damage);
            return DeepCopyObstacle;
        }
    }
}
