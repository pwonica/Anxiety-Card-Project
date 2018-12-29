using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SuggestionSingle : MonoBehaviour {

    public Text displayText;
    private string suggestionText;

    private SuggestionManager suggestionManager;

	// Use this for initialization
	void Start () {
        suggestionManager = FindObjectOfType<SuggestionManager>();
	}

    public void Init(string textToDisplay)
    {
        suggestionText = textToDisplay;
        displayText.text = suggestionText;

    }

    public void ClickSuggestion()
    {
        suggestionManager.AcceptSuggestion(suggestionText);
    }
	
}
