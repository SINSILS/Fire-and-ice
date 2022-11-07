namespace Client._Classes
{
    public class Coin
    {
        public string name { get; set; }
        public PictureBox picBox;

        public List<Part> Parts { get; set; } = new List<Part>();
        public int value;

        public Coin() { }
        public void setInvisible()
        {
            picBox.Visible = false;
        }
        public void setValueAndColor()
        {
            value = Parts.Sum(p => p.Value);
            if (value == 1)
            {
                picBox.BackColor = Color.Yellow;
            }
            else if (value == 2)
            {
                picBox.BackColor = Color.Green;
            }
            else
            {
                picBox.BackColor = Color.Red;
            }
        }
    }
}
