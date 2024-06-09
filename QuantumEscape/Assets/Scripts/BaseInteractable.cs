using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseInteractable : MonoBehaviour
{
    public virtual void Interact()
    {

    }
    public virtual void PickUp()
    {
       
    }

    public virtual void Drop(Vector3 dropPosition)
    {
        transform.position = dropPosition;
    }
}
