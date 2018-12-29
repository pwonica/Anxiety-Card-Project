using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//manages the actual implementation of a tutorial system
public class TutorialManager : MonoBehaviour
{

    public string[] tutorialText;
    public Sprite[] tutorialImages;

    public Image activeImage;
    public Text activeText;
    public string mainMenu;

    private int onScene;
    private int maxScene;

   
    //public SaveManager saveManager;


    // Use this for initialization
    void Start()
    {
        
        maxScene = tutorialText.Length;
        activeText.text = tutorialText[onScene];
        //activeImage.sprite = tutorialImages[onScene];
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    //closes out the village naming sequence and actiates the tutuorial screens
    public void StartTutorial()
    {

        maxScene = tutorialText.Length;
        activeText.text = tutorialText[onScene];
        activeImage.sprite = tutorialImages[onScene];
    }

    public void ClickTutorialButton()
    {
        //activate the button to move to the game
        if (onScene == maxScene - 1)
        {
            //set the save manager to know you went through the tutorial
            PlayerPrefs.SetString("TutorialUsed", "true");
            SceneManager.LoadScene(mainMenu);
        }
        else { NextStep(); }

    }

    private void NextStep()
    {
        onScene++;
        activeText.text = tutorialText[onScene];
        activeImage.sprite = tutorialImages[onScene];

    }

}
