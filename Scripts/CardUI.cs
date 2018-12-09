using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// The card class responsible for physical representations in game. Uses an ID to check for 
/// </summary>

public class CardUI : MonoBehaviour {

    public Text taskText;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //takes a task and sets up the card to be used. 
    public void Init(CardData cardData)
    {
        taskText.text = cardData.cardTask;
    }

}

