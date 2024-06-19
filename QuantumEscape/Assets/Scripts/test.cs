using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : BaseInteractable
{
    private bool isPickedUp = false;
    private Vector3 originalScale;
    private Transform playerTransform;
    private Vector3 heldOffset = new Vector3(0, 5, 0); // Offset above the player's head

    private void Start()
    {
        originalScale = transform.localScale;
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public override void Interact()
    {
        if (!isPickedUp)
        {
            PickUp();
        }
        else
        {
            Drop(playerTransform.position + new Vector3(8, 0, 0));
        }
    }

    public override void PickUp()
    {
        isPickedUp = true;
        GetComponent<Collider2D>().enabled = false;

        transform.SetParent(playerTransform);
        transform.localPosition = heldOffset;
        transform.localScale = originalScale * 0.5f;

        Debug.Log("Picked up the object");
    }

    public override void Drop(Vector3 dropPosition)
    {
        isPickedUp = false;
        SnapToNearestPoint();
        transform.position = dropPosition;
        GetComponent<Collider2D>().enabled = true;
        transform.localScale = originalScale;
        transform.SetParent(null);
        Debug.Log("Dropped the object");
    }

    private void SnapToNearestPoint()
    {
        SnapPoint[] snapPoints = FindObjectsOfType<SnapPoint>();
        SnapPoint nearestSnapPoint = null;
        float nearestDistance = float.MaxValue;

        foreach (SnapPoint snapPoint in snapPoints)
        {
            float distance = Vector3.Distance(transform.position, snapPoint.transform.position);
            if (distance < nearestDistance)
            {
                nearestDistance = distance;
                nearestSnapPoint = snapPoint;
            }
        }

        if (nearestSnapPoint != null)
        {
            transform.position = nearestSnapPoint.snapPosition.position;
            nearestSnapPoint.isOccupied = true;
            PolarizationManager.instance.CheckSnapPoints();
        }
    }

    public void Update()
    {
        //if (isPickedUp && playerTransform != null)
        //{
        //    Debug.Log(playerTransform.position);
        //    // Update the position of the object to be above the player's head
        //    Vector3 playerPosition = playerTransform.position;
        //    Vector3 newPosition = playerPosition + heldOffset;
        //    transform.localPosition = newPosition;

        //   Debug.Log("Held object position: " + transform.position + " with offset: " + heldOffset);
        //}
    }
}
