﻿using Client._Classes;

namespace Client._Patterns_Designs._Adapter_Pattern
{
    internal class FakeCoinAdapter : IFake
    {
        private Coin coin;
        public FakeCoinAdapter(Coin coin)
        {
            this.coin = coin;
        }
        public void isFake()
        {
            coin.picBox.BackColor = Color.White;
            coin.value = 0;
        }
    }
}