using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public int unitMovement;
    private Transform transform;
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

    // Start is called before the first frame update
    void Start()
    {
        transform = GetComponent<Transform>();
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
                    transform.position = new Vector3(transform.position.x, transform.position.y + unitMovement, transform.position.z);
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
                    transform.position = new Vector3(transform.position.x, transform.position.y - unitMovement, transform.position.z);
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
                    transform.position = new Vector3(transform.position.x - unitMovement, transform.position.y, transform.position.z);
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
                    transform.position = new Vector3(transform.position.x + unitMovement, transform.position.y, transform.position.z);
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

        if (heldObject != null && heldObject is test tempObject)
        {
            tempObject.transform.position = transform.position + new Vector3(0, 1, 0); // Adjust this offset as needed
        }
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
                tempObj.Interact();
                heldObject = tempObj;
            }
        }
    }

    void DropObject()
    {
        if (heldObject != null)
        {
            heldObject.Interact();
            heldObject = null;
        }
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
