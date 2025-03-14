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

    public GlyphData glyphData; //name and corresponding latin letter for each glyph


    public Image image;
    public GameObject newGlyph; //Clone glyph when dragged into writing slot
    private bool validDrop = false; //Track if dropped in a valid slot

    public void Start()
    {
        image = GetComponent<Image>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Begin drag");

        //Create a duplicate of the item
        newGlyph = Instantiate(gameObject, transform.position, Quaternion.identity);
        Canvas canvas = GetComponentInParent<Canvas>();
        if (canvas != null) newGlyph.transform.SetParent(canvas.transform, false);

        //Fix weirdness that was causing glyph to not appear at mouse cursor when dragged
        RectTransform newGlyphRect = newGlyph.GetComponent<RectTransform>();
        RectTransform originalRect = GetComponent<RectTransform>();

        newGlyphRect.anchorMin = originalRect.anchorMin;
        newGlyphRect.anchorMax = originalRect.anchorMax;
        newGlyphRect.pivot = originalRect.pivot;
        newGlyphRect.sizeDelta = originalRect.sizeDelta;

        newGlyph.transform.position = Input.mousePosition;
        newGlyph.GetComponent<Image>().raycastTarget = false;
        newGlyph.transform.SetAsLastSibling();

        validDrop = false; //Reset valid drop flag
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("Dragging");
        if (newGlyph != null) newGlyph.transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("End drag");

        if (newGlyph != null)
        {
            if (!validDrop)
            {
                Destroy(newGlyph); //Delete if dropped outside a valid slot
            }
            else
            {
                newGlyph.GetComponent<Image>().raycastTarget = true;
            }
        }
    }

    public void SetValidDrop(bool isValid)
    {
        validDrop = isValid;
    }

    //retrieve letter from glyph
    public string GetLetter()
    {
        return glyphData != null ? glyphData.correspondingLetter : "";
    }

}
