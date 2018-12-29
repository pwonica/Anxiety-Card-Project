using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


/// <summary>
/// Lets you draw random cards and allows you to do different UI related things in drawing
/// </summary>

public class CardDrawController : MonoBehaviour {

    public Text displayTaskText;
    public Text autoCloseTimerText;

    //0 - draw the card, 1 - display the card, 2 - confirmed the card. 
    public GameObject[] panelArray;
    private int onPanel = 0;
    private int closeTimer = 5; 

    CardDataController cardDataController;
	// Use this for initialization
	void Start () {
        cardDataController = FindObjectOfType<CardDataController>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void LoadScene(string whatScene)
    {
        SceneManager.LoadScene(whatScene);
    }

    //a timer that updates every second
    private void AutoCloseTimer()
    {
       
        if (closeTimer <= 1) {
            AdvancePanel();
        }
        else
        {
            closeTimer--;
            Invoke("AutoCloseTimer", 1f);
        }
        autoCloseTimerText.text = closeTimer.ToString();
    }
  
    public void AdvancePanel()
    {
        onPanel++;
        print("on Panel" + onPanel.ToString());
        //if on 2, the last panel, activate the time out feature:
        if (onPanel == 2) { Invoke("AutoCloseTimer", 1f); }
        //if on the last panel, then activate the time out function
        if (onPanel == panelArray.Length)
        {
            onPanel = 0;
        }

        for (int i = 0; i < panelArray.Length; i++)
        {
            if (i == onPanel) { panelArray[i].SetActive(true); }
            else { panelArray[i].SetActive(false); }
        }
    }

    //draws a random card, displays it to the user and switches the UI screen.
    public void DrawCard()
    {
        if (cardDataController.GetCardListCount() > 0)
        {
            print("Getting a random card");
            CardData cardDrawn = cardDataController.GetRandomCardFromDatabase();
            displayTaskText.text = cardDrawn.cardTask;
            AdvancePanel();
            
            cardDataController.LogCardUsed(cardDrawn);
        }
        //error message
        else
        {
            displayTaskText.text = "No cards in database. Create a card first.";
        }
    }
}
