using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public int unitMovement;
    private Transform playerTransform;
    public float cooldownMovement;
    private float currentCooldownMovement;
    public string direction = "down";

    private GameObject colliders;
    private WallCollider upCollider;
    private WallCollider downCollider;
    private WallCollider leftCollider;
    private WallCollider rightCollider;

    private Animator animator;
    private BaseInteractable heldObject;
    private bool isMovementEnabled = true;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GetComponent<Transform>();
        colliders = gameObject.transform.Find("WallColliders").gameObject;
        animator = GetComponent<Animator>();

        upCollider = colliders.transform.Find("WallColliderUp").GetComponent<WallCollider>();
        downCollider = colliders.transform.Find("WallColliderDown").GetComponent<WallCollider>();
        leftCollider = colliders.transform.Find("WallColliderLeft").GetComponent<WallCollider>();
        rightCollider = colliders.transform.Find("WallColliderRight").GetComponent<WallCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isMovementEnabled)
        {
            return; // If movement is disabled, exit the update loop
        }

        if (Input.GetButtonDown("Interact"))
        {
            if (heldObject == null)
            {
                TryPickUpObject();
            }
            else
            {
                DropObject();
            }
        }

        if (Input.GetButtonDown("Interact"))
        {
            if (direction == "up" && upCollider.currentObj != null)
            {
                upCollider.currentObj.Interact();
            }
            if (direction == "down" && downCollider.currentObj != null)
            {
                downCollider.currentObj.Interact();
            }
            if (direction == "left" && leftCollider.currentObj != null)
            {
                leftCollider.currentObj.Interact();
            }
            if (direction == "right" && rightCollider.currentObj != null)
            {
                rightCollider.currentObj.Interact();
            }
        }

        if (currentCooldownMovement <= 0)
        {
            animator.SetBool("isMoving", false);

            bool moved = false;

            if (Input.GetButton("Up"))
            {
                direction = "up";
                animator.SetBool("isMovingUp", true);
                animator.SetBool("isMoving", true);
                if (!upCollider.foundWall)
                {
                    playerTransform.position = new Vector3(playerTransform.position.x, playerTransform.position.y + unitMovement, playerTransform.position.z);
                    currentCooldownMovement = cooldownMovement;
                    moved = true;
                }
            }
            if (Input.GetButton("Down"))
            {
                direction = "down";
                animator.SetBool("isMovingDown", true);
                animator.SetBool("isMoving", true);
                if (!downCollider.foundWall)
                {
                    playerTransform.position = new Vector3(playerTransform.position.x, playerTransform.position.y - unitMovement, playerTransform.position.z);
                    currentCooldownMovement = cooldownMovement;
                    moved = true;
                }
            }
            if (Input.GetButton("Left"))
            {
                direction = "left";
                animator.SetBool("isMovingLeft", true);
                animator.SetBool("isMoving", true);
                if (!leftCollider.foundWall)
                {
                    playerTransform.position = new Vector3(playerTransform.position.x - unitMovement, playerTransform.position.y, playerTransform.position.z);
                    currentCooldownMovement = cooldownMovement;
                    moved = true;
                }
            }
            if (Input.GetButton("Right"))
            {
                direction = "right";
                animator.SetBool("isMovingRight", true);
                animator.SetBool("isMoving", true);
                if (!rightCollider.foundWall)
                {
                    playerTransform.position = new Vector3(playerTransform.position.x + unitMovement, playerTransform.position.y, playerTransform.position.z);
                    currentCooldownMovement = cooldownMovement;
                    moved = true;
                }
            }

            if (!moved)
            {
                ResetMoving();
                switch (direction)
                {
                    case "up":
                        animator.SetBool("isMovingUp", true);
                        break;
                    case "down":
                        animator.SetBool("isMovingDown", true);
                        break;
                    case "left":
                        animator.SetBool("isMovingLeft", true);
                        break;
                    case "right":
                        animator.SetBool("isMovingRight", true);
                        break;
                }
            }
        }
        else
        {
            currentCooldownMovement -= Time.deltaTime;
        }

        //if (heldObject != null && heldObject is test tempObject)
        //{
        //    tempObject.transform.position = playerTransform.position + new Vector3(0, 3, 0); // Adjust this offset as needed
        //}
    }

    public void SetMovementEnabled(bool isEnabled)
    {
        isMovementEnabled = isEnabled;
    }

    void TryPickUpObject()
    {
        WallCollider activeCollider = null;
        switch (direction)
        {
            case "up":
                activeCollider = upCollider;
                break;
            case "down":
                activeCollider = downCollider;
                break;
            case "left":
                activeCollider = leftCollider;
                break;
            case "right":
                activeCollider = rightCollider;
                break;
        }

        if (activeCollider != null && activeCollider.currentObj != null)
        {
            BaseInteractable tempObj = activeCollider.currentObj.GetComponent<BaseInteractable>();
            if (tempObj != null)
            {
                Debug.Log("Interacting with object");
                tempObj.Interact();
                heldObject = tempObj;
            }
        }
        else
        {
            Debug.Log("No interactable object found");
        }
    }

    void DropObject()
    {
        if (heldObject != null)
        {
            Vector3 dropPosition = GetValidDropPosition();
            heldObject.Interact();
            heldObject = null;
        }
    }

    Vector3 GetValidDropPosition()
    {
        Vector3 dropPosition = playerTransform.position;
        switch (direction)
        {
            case "up":
                dropPosition += new Vector3(0, 1, 0);
                break;
            case "down":
                dropPosition += new Vector3(0, -1, 0);
                break;
            case "left":
                dropPosition += new Vector3(-1, 0, 0);
                break;
            case "right":
                dropPosition += new Vector3(1, 0, 0);
                break;
        }

        // Adjust the position further if necessary to avoid overlap
        // For example, add checks to ensure the drop position is not occupied

        return dropPosition;
    }

    void ResetMoving()
    {
        animator.SetBool("isMoving", false);
        animator.SetBool("isMovingDown", false);
        animator.SetBool("isMovingUp", false);
        animator.SetBool("isMovingLeft", false);
        animator.SetBool("isMovingRight", false);
    }

}
