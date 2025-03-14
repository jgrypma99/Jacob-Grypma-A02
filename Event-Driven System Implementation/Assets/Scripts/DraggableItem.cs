using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    //allow dragging and dropping of items between inventory slots
    //taken from this tutorial: https://www.youtube.com/watch?v=kWRyZ3hb1Vc&t=149s
    //modified for the purposes of this project to newGlyph an item instead of moving it
    
    [HideInInspector ]public Transform parentAfterDrag;
    public Image image;
    //newGlyph of the glyph to build the words
    public GameObject newGlyph;

    public void Start()
    {
        image = GetComponent<Image>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Begin drag");

        //create a duplicate of the glyph
        newGlyph = Instantiate(gameObject, transform.position, Quaternion.identity, transform.root);
        newGlyph.GetComponent<Image>().raycastTarget = false; //prevent issues by disabling raycast
        newGlyph.GetComponent<DraggableItem>().newGlyph = newGlyph; //maintian reference to new glyph
        
        // Reset RectTransform to prevent scaling/position issues
        RectTransform newGlyphRect = newGlyph.GetComponent<RectTransform>();
        RectTransform originalRect = GetComponent<RectTransform>();

        newGlyphRect.anchorMin = originalRect.anchorMin;
        newGlyphRect.anchorMax = originalRect.anchorMax;
        newGlyphRect.pivot = originalRect.pivot;
        newGlyphRect.sizeDelta = originalRect.sizeDelta;

        //change parent to canvas to appear on top
        newGlyph.transform.SetAsLastSibling();
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("Dragging");

        //Move the new glyph
        newGlyph.transform.position = Input.mousePosition;
        
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("End drag");
        
        if (newGlyph != null)
        {
            newGlyph.GetComponent<Image>().raycastTarget = true; //re-enable raycasting
        }
    }

}
