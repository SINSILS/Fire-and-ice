using Client._Classes;

namespace Client._Patterns_Designs._Builder_Patern
{
    class RedCoinBuilder : IBuilder
    {
        private Coin coin = new Coin();
        public void AddRing()
        {
            coin.Parts.Add(new Part("Ring", 0));
        }
        public void AddNeckless()
        {
            coin.Parts.Add(new Part("Neckless", 0));
        }
        public void AddCrown()
        {
            coin.Parts.Add(new Part("Crown", 3));
        }
        public Coin GetCoin()
        {
            return coin;
        }
    }
}
