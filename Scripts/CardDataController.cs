using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// runs the card manager system
/// </summary>
public class CardDataController : MonoBehaviour {

    private DataManager dataManager;
    private Canvas canvas;
    private List<GameObject> cardUIList = new List<GameObject>();

    //TODO - this should be private eventually
    public List<CardData> cardDataList = new List<CardData>();



    public GameObject pfabCardCreationPopup;
    public GameObject pfabCardUI;
    public Transform cardDeckContainer;                         // the container that holds all the card UI

    private GameObject activeCardCreatePopup;                   // a reference to the currently active popup in creating a card



	// Use this for initialization
	void Awake () {
        dataManager = FindObjectOfType<DataManager>();
        canvas = FindObjectOfType<Canvas>();
	}

    private void Start()
    {
        LoadCardData();
    }

    //create a card creation popup and then parent it to the Canvas
    public void OpenCardCreationPopup()
    {
        activeCardCreatePopup = Instantiate(pfabCardCreationPopup) as GameObject;
        activeCardCreatePopup.transform.SetParent(canvas.transform, false);
    }

    public void CreateCardInDatabase(string whichTask)
    {
        //create a new Card Data class with the data
        CardData cardData = new CardData(whichTask);
        // add the card to the database
        AddCard(cardData);
        AddCardUI(cardData);
        //create a visual representation of the card
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

    //finds a card and then removes it from the UI
    private void RemoveCardUI(string whichTask)
    {

    }

    private void LoadCardData()
    {

    }

    private void SaveCardData()
    {

    }

    //logs a card as being used and saves data
    public void LogCardUsed(CardData whichCard)
    {
        CardData cardToUse = cardDataList.Find(x => x.cardTask == whichCard.cardTask);
        cardToUse.timesUsed++;
        SaveCardData();
    }

    public void AddCard(CardData cardData)
    {
        cardDataList.Add(cardData);
        //because you're adding a new card, it should be saved
        SaveCardData();
    }

    public void RemoveCard(string whichTask)
    {

    }


    public void DestroyCardCreationPopup()
    {
        if (activeCardCreatePopup != null) { Destroy(activeCardCreatePopup); }
    }
}
