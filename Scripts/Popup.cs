using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The script attached to a generic popup. Used to close popups and do minor tasks connected to the UI Manager. 
/// </summary>
public class Popup : MonoBehaviour {

    private UIManager uiManager;
	// Use this for initialization
	void Start () {
        uiManager = FindObjectOfType<UIManager>();
	}
	
	public void ClosePopup()
    {
        uiManager.ClearPopup();
    }
}
