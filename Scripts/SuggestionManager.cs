using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SuggestionManager : MonoBehaviour {

    //all the text for suggestions
    public string[] suggestionTextArray;

    public Transform suggestionUIContainer;
    public GameObject pfabSuggestionUI;
    
    private List<GameObject> suggestionUIList = new List<GameObject>();
    private CardCreation cardCreation;



    private 
	// Use this for initialization
	void Start () {
        print("in SuggestionManager");
        for (int i = 0; i < suggestionTextArray.Length; i++)
        {
            CreateSuggestionUI(suggestionTextArray[i]);
            print("Creating suggestion card");
        }

        cardCreation = FindObjectOfType<CardCreation>();
    }


    private void CreateSuggestionUI(string suggestionText)
    {
        GameObject objectToCreate = Instantiate(pfabSuggestionUI) as GameObject;
        objectToCreate.transform.SetParent(suggestionUIContainer, false);
        objectToCreate.GetComponent<SuggestionSingle>().Init(suggestionText);
    }
	
    //take the suggestion and close the suggestion popup
	public void AcceptSuggestion(string whichSuggestion)
    {
        cardCreation.TakeSuggestion(whichSuggestion);
        Destroy(gameObject);
    }

    public void CancelSuggestions()
    {
        cardCreation.CloseSuggestions();
    }
}
