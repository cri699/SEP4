using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RememberPhase : MonoBehaviour {

    private Button button;
    private PlacingPhase pp;
    public int count = 0;
    public event EventHandler<ScoreEventArgs> ScoreAdded;
    public event EventHandler<LifeEventArgs> LifeUpdate;
    public Timer timer;
    public static int score;
    int tempCount = 0;


    public GameObject GameManager;

    void Start () {
        button = GameObject.Find("continue").GetComponent<Button>();
        pp = GameObject.FindGameObjectWithTag("PlacingPhase").GetComponent<PlacingPhase>();

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PrepareRememberPhase()
    {
        GameManager.GetComponent<GameManager>().PrepareRememberPhase();

    }

    public void Finish()
    {
        GameObject[] cards = GameObject.FindGameObjectsWithTag("card");

        
        for(int i = 0; i < cards.Length; i++)     // chekcs how many cards were used
        {
            if(cards[i].GetComponent<Draggable>().placedSlot!=0)
            {
                tempCount++;
            }
        }
            for (int i = 0; i < cards.Length; i++)
        {
            if(cards[i].GetComponent<Draggable>().placedSlot == cards[i].GetComponent<Draggable>().rememberSlot && cards[i].GetComponent<Draggable>().wasPlaced == true)
            {
                count++;
            }
        }
        Debug.Log(count);
        GameObject messageText = GameObject.FindGameObjectWithTag("message");


        LifeUpdate(this, new LifeEventArgs(count,tempCount));
        score = count + timer.getTimeLeft();
        ScoreAdded(this, new ScoreEventArgs(score));

        messageText.GetComponent<Text>().text = "You got: " + count + " correct cards!";
        count = 0;

        if(tempCount>=8)
        {
            GameManager.GetComponent<GameManager>().EndGame(score, true);           //BEATING the game
        }
    }
}
