using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Menu = 0, CardTask = 1, CardManage = 2
public enum UIState { Menu, GetCard, CardManage}

public class UIManager : MonoBehaviour {

    public GameObject[] activeScreens;
    private UIState currentScreen;

    private GameObject activePopup;
    private Canvas canvas;
    public static UIManager instance = null;


    private void Awake()
    {
        if (instance == null) { instance = this; }
        else if (instance != this) { Destroy(gameObject); }
        DontDestroyOnLoad(gameObject);
    }

    // Use this for initialization
    void Start () {
        canvas = FindObjectOfType<Canvas>();
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void CreatePopup(GameObject whichPopup)
    {
        activePopup = Instantiate(whichPopup) as GameObject;
        activePopup.transform.SetParent(canvas.transform, false);
    }

    public void ClearPopup()
    {
        if (activePopup != null) { Destroy(activePopup); }
    }

    public void LoadScene(string whichScene)
    {
        SceneManager.LoadScene(whichScene);
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
