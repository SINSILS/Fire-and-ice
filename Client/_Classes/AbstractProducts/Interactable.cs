﻿namespace Client._Classes.AbstractProducts
{
    public abstract class Interactable
    {
        public bool isActivated { get; set; }

        public void SetActivated(bool state)
        {
            isActivated = state;
        }
    }
}
