using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

//implement interfaces so you can BeginDrag, Drag, and EndDrag
public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

    //Gets the parent that this started off with
    public Transform parentToReturnTo = null;
    //
    public Transform placeholderParent = null;

    //This is used to add a space between the cards whenever you move a card near it
    GameObject placeholder = null;

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Check that you get drag");

        //Creates a empty placeholder that's used for the card
        placeholder = new GameObject();
        placeholder.transform.SetParent(this.transform.parent);
        // Add a layout element so you know the general size of the card. 
        LayoutElement le = placeholder.AddComponent<LayoutElement>();
        le.preferredHeight = this.GetComponent<LayoutElement>().preferredHeight;
        le.preferredWidth = this.GetComponent<LayoutElement>().preferredWidth;
        le.flexibleHeight = 0; le.flexibleWidth = 0;

        //SetSiblingIndex is the order of the child, this creates a gap card in the same area you moved this from
        placeholder.transform.SetSiblingIndex(this.transform.GetSiblingIndex());

        parentToReturnTo = this.transform.parent;
        placeholderParent = parentToReturnTo;
        //Move this into the Canvas
        this.transform.SetParent(this.transform.parent.parent);
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        //Moves this based off the position of eventdata, which is your mouse position
        //Note: You can add an offset to this calculation (if you want to drag from the top, bottom, etc
        this.transform.position = eventData.position;

        if (placeholder.transform != placeholder)
        {
            placeholder.transform.SetParent(placeholderParent);
        }
        //This assuming you want to land in the right most spot. By setting to ChildCount (last index), you can place at the end.  
        int newSiblingIndex = parentToReturnTo.childCount;

        //Used to set the position of the card releative to what's under it
        //Goes through the children of the parent (all the cards) and then determines area based on X, Y relative to this card
        for(int i = 0; i < parentToReturnTo.childCount; i++)
        {
            //if your X position is less, then set the sibling index to i, that specific card. Makes the placeholder be at that card's location
            if (this.transform.position.x < placeholderParent.GetChild(i).position.x)
            {
                newSiblingIndex = i;

                if (placeholder.transform.GetSiblingIndex() < newSiblingIndex)
                {
                    newSiblingIndex--;
                }
                //stop this loop, without this, it'll be looking for it way too much.
                break;
            }
        }

        placeholder.transform.SetSiblingIndex(newSiblingIndex);
    }



    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("Drag endded");
        this.transform.SetParent(parentToReturnTo);
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        //Returns you back to the placeholder index
        this.transform.SetSiblingIndex(placeholder.transform.GetSiblingIndex());
        //Since the placeholder card, for creating a gap, is no longer needed, destroy it
        Destroy(placeholder);
    }
}
