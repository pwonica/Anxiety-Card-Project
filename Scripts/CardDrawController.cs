using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Lets you draw random cards and allows you to do different UI related things in drawing
/// </summary>

public class CardDrawController : MonoBehaviour {

    public Text displayTaskText;

    CardDataController cardDataController;
	// Use this for initialization
	void Start () {
        cardDataController = FindObjectOfType<CardDataController>();

    }
	
	// Update is called once per frame
	void Update () {
		
	}


    //draws a random card, displays it to the user and switches the UI screen.
    public void DrawCard()
    {
        if (cardDataController.GetCardListCount() > 0)
        {
            print("Getting a random card");
            CardData cardDrawn = cardDataController.GetRandomCardFromDatabase();
            displayTaskText.text = cardDrawn.cardTask;
            cardDataController.LogCardUsed(cardDrawn);
        }
        //error message
        else
        {
            displayTaskText.text = "No cards in database. Create a card first.";
        }
    }
}
