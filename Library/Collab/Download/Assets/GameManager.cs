using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;



public class GameManager : MonoBehaviour {
    public int lives;
    public Text livesText;
    public RememberPhase rememberPhase;
    public GameObject[] DropSlots;
    public int currentLevel;
    public PlacingPhase pp;

    public GameObject EndGamePanel;
    public Text score, messageText,levelTxt;
    public GameObject scoreText;

    private static System.Random rng;


    [SerializeField] private Text levelText;
    
    void Start () {
        Time.timeScale = 1;
        rememberPhase.LifeUpdate += LifeScript_Update;
        lives = 5;
        livesText.text = "Lives: " + lives;
        currentLevel = 1;
        levelText.text = "Level: "+ currentLevel;
        
        
    }
    
    public void NextLevel()
    {
        if(levelText.text.Equals(""))
        {
            return;
        }
        currentLevel++;
        DropSlots[currentLevel].transform.gameObject.SetActive(true);
        levelText.text = "Level: " + currentLevel;

    }



    public static List<GameObject> Fisher_Yates_CardDeck_Shuffle(List<GameObject> aList)
    {

        System.Random _random = new System.Random();

        GameObject myGO;

        int n = aList.Count;
        for (int i = 0; i < n; i++)
        {
            // NextDouble returns a random number between 0 and 1.
            // ... It is equivalent to Math.random() in Java.
            int r = i + (int)(_random.NextDouble() * (n - i));
            myGO = aList[r];
            aList[r] = aList[i];
            aList[i] = myGO;
        }

        return aList;
    }


    public void PrepareRememberPhase()
    {
        

        pp.cardsPlaced.RemoveRange(0, pp.cardsPlaced.Count);
        GameObject[] cards = GameObject.FindGameObjectsWithTag("card");
        Draggable.inPlacingPhase = false;
        for (int i = 0; i < cards.Length; i++)
        {

            cards[i].transform.SetParent(GameObject.Find("Content").transform);
            cards[i].GetComponent<Draggable>().canBeDragged = true;
            cards[i].GetComponent<CanvasGroup>().blocksRaycasts = true;
        }
        GameObject[] DropSlots = GameObject.FindGameObjectsWithTag("DropSlot");
        for (int i = 0; i < DropSlots.Length; i++)
        {
            DropSlots[i].GetComponent<DropSlot>().isOccupied = false;
        }


        GameObject messageText = GameObject.FindGameObjectWithTag("message");

        messageText.GetComponent<Text>().text = "";
    }

    public void FinishRound()
    {
        pp.UpdateDropSlots();

    }
    
    public void ResetCardPlacingPhase()
    {
        Draggable.inPlacingPhase = true;
    }

    public void EndGame(int score, bool isWin)
    {
        EndGamePanel.SetActive(true);
        if (isWin)
        {
            messageText.text = "Congratulations! You won!";
        } 
        this.score.text = "Score: " + score.ToString();
        livesText.text = "";
        scoreText.SetActive(false);
        levelText.text = "";
        levelTxt.text = "Level: " + currentLevel;

        AudioManagerScript.instance.playEndGame();       //audio

        Time.timeScale = 0;
    }
   


    private void LifeScript_Update(object sender, LifeEventArgs e)
    {
        //score = score + e.Score;
        lives = lives - (e.TotalCards - e.Life);
        livesText.text = "Lives: " + lives;
        if(lives < 0 )
        {
            EndGame(RememberPhase.score, false);
        }
    }
}
