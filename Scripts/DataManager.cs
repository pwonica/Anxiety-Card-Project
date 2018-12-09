using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DataManager : MonoBehaviour {

    //TODO - this should be private eventually
    public List<CardData> cardDataList = new List<CardData>();


	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(gameObject);
        LoadCardData();
        //load the actual game
    }

    // Update is called once per frame
    void Update () {
		
	}

    private void LoadCardData()
    {

    }

    private void SaveCardData()
    {

    }

    public int GetCardListCount() { return cardDataList.Count; }

    public CardData GetCardByIndex(int whichIndex) { return cardDataList[whichIndex]; }

  

    //recieves a card and adds it to the database
    public void AddCard(CardData cardData)
    {
        cardDataList.Add(cardData);
        //because you're adding a new card, it should be saved
        SaveCardData();
    }

    public void RemoveCard(string whichTask)
    {

    }
}
