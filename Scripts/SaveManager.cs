using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveManager : MonoBehaviour {

	// Use this for initialization


    public static void SaveData(List<CardData> cardDataList)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream stream = new FileStream(Application.persistentDataPath + "/player.sav", FileMode.Create);
        //saves all the card data to the UserSaveData class
        UserSaveData data = new UserSaveData(cardDataList);
        bf.Serialize(stream, data);
        stream.Close();
        print("Game saved");
    }

    //Get the card data list from the saved data, return null for an error 
    public static List<CardData> GetSavedCardList()
    {
        UserSaveData data = GetUserSaveData();

        if (GetUserSaveData() != null) { return data.savedCardsList; }
        else { Debug.LogError("Cannot get card list."); return null; }
    }

    private static UserSaveData GetUserSaveData()
    {
        if (File.Exists(Application.persistentDataPath + "/player.sav"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream stream = new FileStream(Application.persistentDataPath + "/player.sav", FileMode.Open);

            //doesn't actually know what game object it is so you need to cast it as the object
            UserSaveData data = bf.Deserialize(stream) as UserSaveData;
            stream.Close();
            print("Loading game finished");
            return data;
        }
        else
        {
            Debug.LogError("File does not exist");
            return null;
        }
    }

    public static bool DoesSaveDataExist()
    {
        if (File.Exists(Application.persistentDataPath + "/player.sav")) { return true; }
        else { return false; }

    }

}

[Serializable]
public class UserSaveData
{
    public List<CardData> savedCardsList = new List<CardData>();

    public UserSaveData(List<CardData> currentCardDataList)
    {
        foreach(CardData cardData in currentCardDataList)
        {
            CardData newDataToSave = new CardData();
            newDataToSave.cardTask = cardData.cardTask;
            newDataToSave.timesUsed = cardData.timesUsed;
            savedCardsList.Add(newDataToSave);
        }
    }
}
