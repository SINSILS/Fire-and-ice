using Client._Classes;

namespace Client._Patterns_Designs._Adapter_Pattern
{
    public class FakeCoinAdapter : IFake
    {
        private Coin coin;
        public FakeCoinAdapter(Coin coin)
        {
            if (coin == null) { throw new ArgumentNullException(); }
            this.coin = coin;
        }
        public void isFake()
        {
            coin.picBox.BackColor = Color.White;
            coin.value = 0;
        }

        public int getValue()
        {
            return coin.value;
        }
    }
}
