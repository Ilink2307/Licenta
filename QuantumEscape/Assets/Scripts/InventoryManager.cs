using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public InventorySlot[] inventorySlots; // Assign all inventory slots in the inspector
    public Canvas inventoryCanvas; // Assign the inventory canvas in the inspector
    public OpenMinigame openMinigame;
    public GameObject targetObject; // Object to change color
    public Color targetColor = Color.green; // Desired color
    public void CheckOrder()
    {
        foreach (InventorySlot slot in inventorySlots)
        {
            if (!slot.IsCorrectItem())
            {
                return; // If any slot does not have the correct item, return
            }
        }

        // If all slots have the correct items, close the canvas
        CloseCanvas();
        ChangeObjectColor();
        DisableInteraction();
    }

    private void CloseCanvas()
    {
        inventoryCanvas.gameObject.SetActive(false);

        if (openMinigame != null)
        {
            openMinigame.CloseCanvas();
        }
        else
        {
            Debug.LogWarning("OpenMinigame reference is not assigned.");
        }
    }
    private void ChangeObjectColor()
    {
        if (targetObject != null)
        {
            Renderer renderer = targetObject.GetComponent<Renderer>();
            if (renderer != null)
            {
                Material material = renderer.material;
                material.color = targetColor;
                material.SetColor("_BaseColor", targetColor); // For URP/LWRP
                material.SetColor("_Color", targetColor); // For standard shaders
            }
            else
            {
                Debug.LogWarning("No Renderer found on target object.");
            }
        }
        else
        {
            Debug.LogWarning("Target object reference is not assigned.");
        }
    }

    private void DisableInteraction()
    {
        if (openMinigame != null)
        {
            openMinigame.DisableInteraction();
        }
    }
}
