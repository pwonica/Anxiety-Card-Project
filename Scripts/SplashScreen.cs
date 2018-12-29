using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SplashScreen : MonoBehaviour {

    public string menuScreenString;
    public string alternativeLoadString;
    public float loadTime;

	// Use this for initialization
	void Start () {
        Invoke("RunSplashScreen", loadTime);
	}
	
    private void RunSplashScreen()
    {
        //optional fade in and out
        if (PlayerPrefs.GetString("TutorialUsed") == "false")
        {
            //load the tutorial
            SceneManager.LoadScene(alternativeLoadString);
        }
        else
        {
            SceneManager.LoadScene(menuScreenString);
        }

    }


	// Update is called once per frame
	void Update () {
		
	}
}
