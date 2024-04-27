using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public int unitMovement;
    private Transform transform;
    public float cooldownMovement;
    private float currentCooldownMovement;

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
            }
            if (Input.GetButton("Down") && !downCollider.foundWall)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y - unitMovement, transform.position.z);
                currentCooldownMovement = cooldownMovement;
                ResetMoving();
                animator.SetBool("isMovingDown", true);
                animator.SetBool("isMoving", true);
            }
            if (Input.GetButton("Left") && !leftCollider.foundWall)
            {
                transform.position = new Vector3(transform.position.x - unitMovement, transform.position.y, transform.position.z);
                currentCooldownMovement = cooldownMovement;
                ResetMoving();
                animator.SetBool("isMovingLeft", true);
                animator.SetBool("isMoving", true);
            }
            if (Input.GetButton("Right") && !rightCollider.foundWall)
            {
                transform.position = new Vector3(transform.position.x + unitMovement, transform.position.y, transform.position.z);
                currentCooldownMovement = cooldownMovement;
                ResetMoving();
                animator.SetBool("isMovingRight", true);
                animator.SetBool("isMoving", true);
            }
        }
        else
        {
            currentCooldownMovement -= Time.deltaTime;
        }
    }

    void ResetMoving()
    {
        animator.SetBool("isMovingDown", false);
        animator.SetBool("isMovingUp", false);
        animator.SetBool("isMovingLeft", false);
        animator.SetBool("isMovingRight", false);
        animator.SetBool("isMoving", false);
    }
}
