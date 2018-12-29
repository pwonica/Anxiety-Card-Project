using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// The card class responsible for physical representations in game. Uses an ID to check for 
/// </summary>

public class CardUI : MonoBehaviour {

    public Text taskText;
    public Text timesUsed;
    public CardData cardDataReference;              //stores a reference to the card data so it can find itself in a list. 
    private CardDataController cardDataController;

	// Use this for initialization
	void Start () {
        cardDataController = FindObjectOfType<CardDataController>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //sends a command to the manager to delete the card from the system
    public void DeleteCard()
    {
        cardDataController.RemoveCard(cardDataReference);
        
    }

    //takes a task and sets up the card to be used. 
    public void Init(CardData cardData)
    {
        taskText.text = cardData.cardTask;
        timesUsed.text = cardData.timesUsed.ToString() ;
        cardDataReference = cardData;
    }



}

