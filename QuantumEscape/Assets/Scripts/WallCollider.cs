using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCollider : MonoBehaviour
{

    public bool foundWall = false;
    public BaseInteractable currentObj;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision == null) return;

        if (collision.gameObject.tag == "Wall")
        {
            foundWall = true;
        }
        else if(collision.gameObject.tag == "Interactable")
        {
            foundWall = true;
            List<BaseInteractable> interactables = new List<BaseInteractable>();
            Utils.GetInterfaces<BaseInteractable>(out interactables, collision.gameObject);
            currentObj = interactables[0];
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision == null) return;

        if (collision.gameObject.tag == "Wall")
        {
            foundWall = false;
        }
        else if (collision.gameObject.tag == "Interactable")
        {
            foundWall = false;
            currentObj = null;
        }
    }

}