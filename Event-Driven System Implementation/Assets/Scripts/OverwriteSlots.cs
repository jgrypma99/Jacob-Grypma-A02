using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

//overwrites slot with new glyph when dragged into an already occupied slot

public class OverwriteSlots : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        GameObject draggedObject = eventData.pointerDrag;

        if (draggedObject != null)
        {
            DraggableItem draggedItem = draggedObject.GetComponent<DraggableItem>();

            if (draggedItem != null && draggedItem.newGlyph != null)
            {
                // Capture old item BEFORE assigning the new one
                GameObject oldItem = (transform.childCount > 0) ? transform.GetChild(0).gameObject : null;

                // Assign the new item
                draggedItem.newGlyph.transform.SetParent(transform);
                draggedItem.newGlyph.transform.localPosition = Vector3.zero; // Align properly
                draggedItem.SetValidDrop(true); // Mark as a valid drop

                // Only delete the old item if it's different from the new one
                if (oldItem != null && oldItem != draggedItem.newGlyph)
                {
                    Destroy(oldItem);
                }
            }
        }
    }
}
