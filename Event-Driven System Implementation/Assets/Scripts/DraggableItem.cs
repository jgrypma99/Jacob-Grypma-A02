using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    //allow dragging and dropping of items between inventory slots
    //taken from this tutorial: https://www.youtube.com/watch?v=kWRyZ3hb1Vc&t=149s
    [HideInInspector ]public Transform parentAfterDrag;
    public Image image;

    public void Start()
    {
        image = GetComponent<Image>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Begin drag");
        
        //change parent to canvas to allow for item to appear on top of everything else
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        
        //hide item from raycasting during drag to enable moving to new slot
        image.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("Dragging");

        //set position of item to posiition of mouse cursor
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("End drag");
        
        //change parent to new slot
        transform.SetParent(parentAfterDrag);

        //re-enable raycasting to allow for dragging once again
        image.raycastTarget = true;
    }

}
