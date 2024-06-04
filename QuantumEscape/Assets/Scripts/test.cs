using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : BaseInteractable
{
    private bool isPickedUp = false;

    public override void Interact()
    {
        if (!isPickedUp)
        {
            PickUp();
        }
        else
        {
            Drop();
        }
    }

    public override void PickUp()
    {
        isPickedUp = true;
        // Disable the collider to prevent further interactions while being held
        GetComponent<Collider2D>().enabled = false;
        Debug.Log("Picked up the object");
    }

    public override void Drop()
    {
        isPickedUp = false;
        // Re-enable the collider
        GetComponent<Collider2D>().enabled = true;
        Debug.Log("Dropped the object");
    }

}
