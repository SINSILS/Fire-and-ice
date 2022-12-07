using Client._Classes;

namespace Client._Patterns_Designs._Builder_Patern
{
    public class GreenCoinBuilder : IBuilder
    {
        private Coin coin = new Coin();
        public void AddRing()
        {
            coin.Parts.Add(new Part("Ring", 0));
        }
        public void AddNeckless()
        {
            coin.Parts.Add(new Part("Neckless", 2));
        }
        public void AddCrown()
        {
            coin.Parts.Add(new Part("Crown", 0));
        }
        public Coin GetCoin()
        {
            return coin;
        }
    }
}
