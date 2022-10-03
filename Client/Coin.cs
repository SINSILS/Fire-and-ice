using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class Coin
    {
        public string name { get; set; }
        public PictureBox coin { get; set; }
        //For future updates, when coins will have different values example: [yellow, 1]; [blue, 2]; [purple; 3]
        public Dictionary<string, int> value = new Dictionary<string, int>();

    public Coin(PictureBox coin)
        {
            this.coin = coin;
            name = coin.Name;
        }

        public void setInvisible()
        {
            coin.Visible = false;
        }
    }
}
