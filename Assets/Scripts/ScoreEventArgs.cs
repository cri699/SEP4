using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreEventArgs : EventArgs{

    public int Score;
   
    public ScoreEventArgs(int score)
    {
        Score = score;
    }
}
