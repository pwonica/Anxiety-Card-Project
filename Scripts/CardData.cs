using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CardData
{
    public string cardTask;
    private int cardID;

    //placeholders for future variables
    private int usefullnessScore;
    public int timesUsed;

    public CardData(string whichTask)
    {
        cardTask = whichTask;
        //genereate a random id for this
    }
}