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
    public Color targetColorWhenUnsolved = Color.red;

    private Renderer targetRenderer;
    private Material targetMaterial;

    private void Start()
    {
        targetRenderer = targetObject.GetComponent<Renderer>();
        if (targetRenderer != null)
        {
            targetMaterial = targetRenderer.material;
            // Set initial color to red (or whatever initial color you want)
            targetMaterial.color = targetColorWhenUnsolved;
        }
        else
        {
            Debug.LogWarning("No Renderer found on target object.");
        }
    }
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
        if (targetMaterial != null)
        {
            // Change the color to green when puzzle is solved
            targetMaterial.color = targetColor;
        }
        else
        {
            Debug.LogWarning("Target material reference is not assigned.");
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
