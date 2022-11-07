using Client._Classes;

namespace Client._Patterns_Designs._Builder_Patern
{
    public interface IBuilder
    {
        void AddRing();
        void AddNeckless();
        void AddCrown();
        Coin GetCoin();
    }
}
