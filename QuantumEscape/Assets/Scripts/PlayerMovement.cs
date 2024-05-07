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
            if(direction == "up" && upCollider.currentObj != null)
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

        if(currentCooldownMovement<=0)
        {
            animator.SetBool("isMoving", false);
            if (Input.GetButton("Up") && !upCollider.foundWall)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + unitMovement, transform.position.z);
                currentCooldownMovement = cooldownMovement;
                ResetMoving();
                animator.SetBool("isMovingUp", true);
                animator.SetBool("isMoving", true);
                direction = "up";
            }
            if (Input.GetButton("Down") && !downCollider.foundWall)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y - unitMovement, transform.position.z);
                currentCooldownMovement = cooldownMovement;
                ResetMoving();
                animator.SetBool("isMovingDown", true);
                animator.SetBool("isMoving", true);
                direction = "down";
            }
            if (Input.GetButton("Left") && !leftCollider.foundWall)
            {
                transform.position = new Vector3(transform.position.x - unitMovement, transform.position.y, transform.position.z);
                currentCooldownMovement = cooldownMovement;
                ResetMoving();
                animator.SetBool("isMovingLeft", true);
                animator.SetBool("isMoving", true);
                direction = "left";

            }
            if (Input.GetButton("Right") && !rightCollider.foundWall)
            {
                transform.position = new Vector3(transform.position.x + unitMovement, transform.position.y, transform.position.z);
                currentCooldownMovement = cooldownMovement;
                ResetMoving();
                animator.SetBool("isMovingRight", true);
                animator.SetBool("isMoving", true);
                direction = "right";

            }
        }
        else
        {
            currentCooldownMovement -= Time.deltaTime;
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
