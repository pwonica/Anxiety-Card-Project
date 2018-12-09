using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Controls the popup for creating a new card. Allows you to accept user input and then talks with the CardDataController to create new cards
/// to be added into the database
/// </summary>

public class CardCreation : MonoBehaviour {

    //public Text placeholderText;
    //public Text userInputText;
    public InputField userInput;


    private CardDataController cardDataController;
	// Use this for initialization
	void Start () {
        cardDataController = FindObjectOfType<CardDataController>();
	}

    //sets the placeholder text to the user input
    public void ApplyUserInput()
    {
        //placeholderText.text = userInputText.text;
    }


    //sends data to CardDataController to create a new card
    public void ConfirmCardCreation()
    {
        //add the card to the database
        print("Creating card with task: " + userInput.text);
        cardDataController.CreateCardInDatabase(userInput.text);
        //close this popup
        ClosePopup();
    }

    public void ClosePopup()
    {
        cardDataController.DestroyCardCreationPopup();
    }

}
