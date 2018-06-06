using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    public int timeLeft = 5;
    public Text countdownText;
    public GameManager gameManager;

    // Use this for initialization
    void Start()
    {
        StartCoroutine("LoseTime");
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    public int getTimeLeft()
    {
        Debug.Log(timeLeft +"TIME LEFT");
        return timeLeft;
    }

    // Update is called once per frame
    void Update()
    {
        countdownText.text = ("Time Left = " + timeLeft);

        if (timeLeft <= 0)
        {
            StopCoroutine("LoseTime");
            countdownText.text = "Times Up!";
            gameManager.EndGame(RememberPhase.score, false);

        }
    }

    IEnumerator LoseTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            timeLeft--;
        }
    }
}
