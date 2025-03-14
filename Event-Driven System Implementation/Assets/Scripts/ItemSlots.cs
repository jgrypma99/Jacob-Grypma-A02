using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlots : MonoBehaviour, IDropHandler
{
    //script to allow item to be moved to new slot upon release of drag/drop function
    public void OnDrop(PointerEventData eventData)
    {
        GameObject dropeed = eventData.pointerDrag;
        DraggableItem draggableItem = dropeed.GetComponent<DraggableItem>();
        draggableItem.parentAfterDrag = transform;
    }

}
