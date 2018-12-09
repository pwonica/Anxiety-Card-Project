using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Dropzone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler {

    public void OnPointerEnter(PointerEventData eventData)
    {
        //prevents exceptions - if nothing's being dragged, you don't have to do anything
        if (eventData.pointerDrag == null) { return; }

        Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
        //it's good to check if there is a draggable object at all here for error handlign
        if (d != null)
        {
            //override the placeholder parent 
            d.placeholderParent = this.transform;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //prevents exceptions - if nothing's being dragged, you don't have to do anything
        if (eventData.pointerDrag == null) { return; }

        Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
        //Checks to see if there's a valid exit 
        if (d != null && d.placeholderParent == this.transform)
        {
            //override the placeholder parent so a card from a different drop zone can enter
            d.placeholderParent = d.parentToReturnTo;
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        //Gets the name of the object that was dragged on top 
        Debug.Log(eventData.pointerDrag.name + " was dropped on" + gameObject.name);

        Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
        //it's good to check if there is a draggable object at all here for error handlign
        if (d != null)
        {
            //override the parent to return to and set it to this dropzone
            d.parentToReturnTo = this.transform;
        }

    }
}
