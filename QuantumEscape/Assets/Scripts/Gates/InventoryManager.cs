using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public InventorySlot[] inventorySlots;
    public Canvas inventoryCanvas; // Assign the inventory canvas in the inspector
    public OpenMinigame openMinigame;
    public GameObject targetObject; // Object to change color
    public GameObject cableObject;
    public Color targetColor = Color.green; // Desired color
    public Color targetColorWhenUnsolved = Color.red;
    public Color cableColor = Color.blue; // Desired color

    private SpriteRenderer targetRenderer;
    //private Material targetMaterial;
    private SpriteRenderer cableRenderer;
    //private Material cableMaterial;

    private void Start()
    {
        targetRenderer = targetObject.GetComponent<SpriteRenderer>();
        cableRenderer = cableObject.GetComponent<SpriteRenderer>();
        if (targetRenderer != null && cableRenderer)
        {
            //targetMaterial = targetRenderer.material;
            targetRenderer.color = targetColorWhenUnsolved;
            //cableMaterial = cableRenderer.material;
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
                return; 
            }
        }

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
        //if (targetMaterial != null && cableMaterial!=null)
        //{
        // Change the color to green when puzzle is solved
        targetRenderer.color = targetColor;
        cableRenderer.color = cableColor;
        //}
        //else
        //{
            //Debug.LogWarning("Target material reference is not assigned.");
        //}
    }

    private void DisableInteraction()
    {
        if (openMinigame != null)
        {
            openMinigame.DisableInteraction();
        }
    }
}
