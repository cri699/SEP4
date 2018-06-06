using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    // Use this for initialization

    public Text scoreText;
    public RememberPhase rememberPhase;
    private int score;
    


    void Start () {
        rememberPhase.ScoreAdded += ScoreScript_ScoreAdded;
       // timer.
        score = 0;
        //UpdateScore();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void ScoreScript_ScoreAdded(object sender, ScoreEventArgs e)
    {
        score = score + e.Score;
        scoreText.text = "Score: " + score;


    }

    //public void AddScore(int newScoreValue)
    //{
    //    score += newScoreValue;
    //    UpdateScore();
    //}

    //void UpdateScore()
    //{
    //    scoreText.text = "Score: " + score;
    //}
}
