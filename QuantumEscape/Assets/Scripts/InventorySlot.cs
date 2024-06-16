using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IDropHandler
{
    public InventoryManager inventoryManager;
    public void OnDrop(PointerEventData eventData)
    {
        if(transform.childCount == 0)
        {
            GameObject dropped = eventData.pointerDrag;
            DraggableItem draggableItem =dropped.GetComponent<DraggableItem>();
            draggableItem.parentAfterDrag = transform;
            dropped.transform.SetParent(transform);

            inventoryManager.CheckOrder();
        }
        

    }
    public bool IsCorrectItem()
    {
        if (transform.childCount > 0)
        {
            GameObject currentItem = transform.GetChild(0).gameObject;
            return currentItem.name == this.name; // Compare the name of the item with the slot's name
        }
        return false;
    }

}
