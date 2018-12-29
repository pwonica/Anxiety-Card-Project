using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// runs the card manager system. Loads cards on startup
/// </summary>
public class CardDataController : MonoBehaviour {

    private SaveManager saveManager;
    private Canvas canvas;
    public List<GameObject> cardUIList = new List<GameObject>();

    //TODO - this should be private eventually
    public List<CardData> cardDataList = new List<CardData>();



    public GameObject pfabCardCreationPopup;
    public GameObject pfabCardUI;
    public Transform cardDeckContainer;                         // the container that holds all the card UI

    private GameObject activeCardCreatePopup;                   // a reference to the currently active popup in creating a card



	// Use this for initialization
	void Awake () {
        saveManager = FindObjectOfType<SaveManager>();
        canvas = FindObjectOfType<Canvas>();
	}

    private void Start()
    {
        LoadCardData();
    }

    public void CreateCardInDatabase(string whichTask)
    {
        //create a new Card Data class with the data
        CardData cardData = new CardData();
        cardData.cardTask = whichTask;
        // add the card to the database
        cardDataList.Add(cardData);
        AddCardUI(cardData);
        //because you're creating a card, save it to player data
        SaveCardData();
        //create a visual representation of the card
    }

    public void CreateCardFromDatabase(CardData cardData)
    {
        cardDataList.Add(cardData);
        AddCardUI(cardData);
        SaveCardData();
    }

    public int GetCardListCount() { return cardDataList.Count; }

    public CardData GetRandomCardFromDatabase()
    {
        int whichCard = Random.Range(0, cardDataList.Count);
        return cardDataList[whichCard];
    }

    //recieves card data and then creates a relevant UI element to display that
    private void AddCardUI(CardData cardData)
    {
        GameObject objectToCreate = Instantiate(pfabCardUI) as GameObject;
        objectToCreate.transform.SetParent(cardDeckContainer, false);
        //initializes the card by setting it's text based off the card data received. 
        objectToCreate.GetComponent<CardUI>().Init(cardData);
        cardUIList.Add(objectToCreate);
    }

    //finds a specific card and removes both it's card data and UI object
    public void RemoveCard(CardData cardData)
    {
        //find the UI element associated with that card data
        GameObject cardUIObject = cardUIList.Find(x => x.GetComponent<CardUI>().cardDataReference == cardData);
        if(cardUIObject != null)
        {
            print("Card UI deleted");
            cardUIList.Remove(cardUIObject);
            GameObject.Destroy(cardUIObject);
        }
        else
        {
            Debug.Log("Could not find card in UI list, possible error");
        }
        //removes the card from the data list 
        cardDataList.Remove(cardData);
        //save the card data to confirm that it's no longer there
        SaveCardData();
    }

    //gets a list of the card data from the data manager and loads it into the list, creating ui 
    private void LoadCardData()
    {
        //gets a list of all the card data and from that, creates relevant UI for it. 
        List<CardData> cardDataList = SaveManager.GetSavedCardList();
        foreach(CardData cardData in cardDataList)
        {
            CreateCardFromDatabase(cardData);
        }
    }

    private void SaveCardData()
    {
        //print("Starting to save total: " + cardDataList.Count);
        SaveManager.SaveData(cardDataList);
    }

    //logs a card as being used and saves data
    public void LogCardUsed(CardData whichCard)
    {
        CardData cardToUse = cardDataList.Find(x => x.cardTask == whichCard.cardTask);
        cardToUse.timesUsed++;
        SaveCardData();
    }

    //clears every card and UI element.
    public void ClearDatabase()
    {
        //delete card data

        for (int i = 0; i < cardDataList.Count; i++)
        {
            RemoveCard(cardDataList[i]);
        }
        /*
        foreach (CardData cardData in cardDataList)
        {
            RemoveCard(cardData);
            
        }
        */
        print("all card data and UI has been deleted");

    }

    public void DestroyCardCreationPopup()
    {
        if (activeCardCreatePopup != null) { Destroy(activeCardCreatePopup); }
    }
}
