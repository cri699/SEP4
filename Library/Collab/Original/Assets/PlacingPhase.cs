﻿
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlacingPhase : MonoBehaviour {

    
    public List<GameObject> cardsPlaced;
    
    
    public int dropSlots;
    private Button continueButton;
    public Button finishButton;

	// Use this for initialization
	void Start () {
        cardsPlaced = new List<GameObject>();
        dropSlots = GameObject.FindGameObjectsWithTag("DropSlot").Length;
        Debug.Log(dropSlots);
        continueButton = GameObject.Find("continue").GetComponent<Button>();
        continueButton.interactable = false;

    }

    



  

    public void UpdateDropSlots()
    {
        dropSlots = GameObject.FindGameObjectsWithTag("DropSlot").Length;
    } 

    public void addCard(GameObject go)
    {
        cardsPlaced.Add(go);
        
        
        if(cardsPlaced.Count == dropSlots)
        {
            GameObject messageText = GameObject.FindGameObjectWithTag("message");
            messageText.SetActive(true);
            messageText.GetComponent<Text>().text = "Now remember their order!";

            continueButton.interactable = true;
        }
        
    }
    public void addCardInRemember(GameObject go)
    {
        Debug.Log("Did this");
        cardsPlaced.Add(go);
        

        if (cardsPlaced.Count == dropSlots)
        {
            GameObject messageText = GameObject.FindGameObjectWithTag("message");
            messageText.SetActive(true);
            messageText.GetComponent<Text>().text = "Click Finish!";

            finishButton.gameObject.SetActive(true);
            finishButton.interactable = true;
        }

    }
    public void removeCard(GameObject go)
    {
        cardsPlaced.Remove(go);
    }
    public bool CheckCard(GameObject go)
    {
        return cardsPlaced.Contains(go);
    }
}
