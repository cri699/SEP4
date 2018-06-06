using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeEventArgs : EventArgs{

    public int Life;
    public int TotalCards;
   
    public LifeEventArgs(int life, int totalCards)
    {
        Life = life;
        TotalCards = totalCards;
    }
}
