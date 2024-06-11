using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenMinigame : BaseInteractable
{
    public GameObject interactionCanvas;
    private PlayerMovement playerMovement;

    void Start()
    {
        if (interactionCanvas != null)
        {
            interactionCanvas.SetActive(false); //canvas is inactive
        }
        playerMovement = FindObjectOfType<PlayerMovement>();
    }

    public override void Interact()
    {
        if (interactionCanvas != null)
        {
            interactionCanvas.SetActive(true); // activate canvas when interacting
            CanvasStuff canvasStuff = interactionCanvas.GetComponent<CanvasStuff>();
            canvasStuff.openMinigame = this;
            if (playerMovement != null)
            {
                playerMovement.SetMovementEnabled(false); // disable player movement
            }
        }
        else
        {
            Debug.LogWarning("Interaction Canvas is not assigned.");
        }
    }

    public void CloseCanvas()
    {
        if (interactionCanvas != null)
        {
            interactionCanvas.SetActive(false);
            if (playerMovement != null)
            {
                playerMovement.SetMovementEnabled(true); // enable player movement
            }
        }
    }
}
