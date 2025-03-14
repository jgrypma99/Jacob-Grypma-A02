using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlots : MonoBehaviour, IDropHandler
{
    //script to allow item to be moved to new slot upon release of drag/drop function
    public void OnDrop(PointerEventData eventData)
    {
        GameObject draggedObject = eventData.pointerDrag;

        if (draggedObject != null && transform.childCount == 0)
        {
            DraggableItem draggedItem = draggedObject.GetComponent<DraggableItem>();

            if (draggedItem != null && draggedItem.newGlyph != null)
            {
                // Set the newGlyph as the child of the new slot
                draggedItem.newGlyph.transform.SetParent(transform);
                draggedItem.newGlyph.transform.localPosition = Vector3.zero; // Align properly
            }
        }
    }

}
