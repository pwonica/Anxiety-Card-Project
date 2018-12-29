using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// Used to create UI objects with multiple panels, such as shop screens, etc for management. 
/// To use:
///     - Script must be attached to a central game object. All children are the panels
///     - Any panel must have the UI_MultiPanelSingle included. This allows you to update buttons colors
/// </summary>

public class UI_MultiPanelController : MonoBehaviour
{
    //the actual gameobject panels that are switched between
    public GameObject[] panelsOverview;
    //the buttons used to activate each panel. 
    public GameObject[] panelButtons;
    public int startingPanelIndex;
    public bool isActive;

    public Color activeColor;
    public Color inactiveColor;

    // Use this for initialization
    void Start()
    {
        isActive = false;
        //set the Default State
        OpenSpecificPanel(startingPanelIndex);
    }
   

    public void OpenSpecificPanel(int whichPanel)
    {
        print("Making Active Panel: " + whichPanel.ToString());
        SetActivePanel(whichPanel);
    }

    private void SetActivePanel(int whichPanel)
    {
        //update the panel states
        for (int i = 0; i < panelsOverview.Length; i++)
        {
            if (i == whichPanel) { SetPanelState(i, true); }
            else { SetPanelState(i, false); }
        }
    }

    private void SetButtonState(int whichButton, bool whichState)
    {
        if (whichState == true) { panelButtons[whichButton].GetComponent<Button>().image.color = activeColor; }
        else { panelButtons[whichButton].GetComponent<Button>().image.color = inactiveColor; }
   
    }


    //set the respective panel to a new state, based on that state, update the button
    private void SetPanelState(int whichIndex, bool whichState)
    {
        panelsOverview[whichIndex].SetActive(whichState);
        SetButtonState(whichIndex, whichState);
    }


}
