using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Menu = 0, CardTask = 1, CardManage = 2
public enum UIState { Menu, GetCard, CardManage}

public class UIManager : MonoBehaviour {

    public GameObject[] activeScreens;
    private UIState currentScreen; 
    

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //takes a scene by int and opens it, closing all other scenes.
    public void OpenScreen(int whichScene)
    {
        //make a for loop that goes through the active scenes, opens relavent ones and shuts down non relevant. 
        for(int i = 0; i < activeScreens.Length; i++)
        {
            if (i == whichScene)
            {
                activeScreens[i].SetActive(true);
                currentScreen = (UIState)whichScene;
                print(currentScreen);
            }
            else { activeScreens[i].SetActive(false); }
        }
    }
}
