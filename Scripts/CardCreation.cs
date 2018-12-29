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
    public GameObject pfabSuggestionsPanel;

    private CardDataController cardDataController;
    private GameObject suggestionsPanel;
    private Canvas canvas;
    // Use this for initialization
    void Start() {
        cardDataController = FindObjectOfType<CardDataController>();
        canvas = FindObjectOfType<Canvas>();
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
        //tells the ui manager to delete it's current popup
        UIManager.instance.ClearPopup();
    }

    //create the suggestion panel
    public void OpenSuggestions()
    {
        //creates a new suggestion panel
        suggestionsPanel = Instantiate(pfabSuggestionsPanel) as GameObject;
        suggestionsPanel.transform.SetParent(canvas.transform, false);
    }

    public void TakeSuggestion(string suggestionText)
    {
        userInput.text = suggestionText;
        CloseSuggestions();
    }

    public void CloseSuggestions()
    {
        if (suggestionsPanel != null) { Destroy(suggestionsPanel); }
    }


}
