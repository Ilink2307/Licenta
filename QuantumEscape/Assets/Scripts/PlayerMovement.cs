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

    // Start is called before the first frame update
    void Start()
    {
        transform = GetComponent<Transform>();
        colliders = gameObject.transform.Find("WallColliders").gameObject;

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
            if (Input.GetButton("Up") && !upCollider.foundWall)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + unitMovement, transform.position.z);
                currentCooldownMovement = cooldownMovement;
            }
            if (Input.GetButton("Down") && !downCollider.foundWall)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y - unitMovement, transform.position.z);
                currentCooldownMovement = cooldownMovement;
            }
            if (Input.GetButton("Left") && !leftCollider.foundWall)
            {
                transform.position = new Vector3(transform.position.x - unitMovement, transform.position.y, transform.position.z);
                currentCooldownMovement = cooldownMovement;
            }
            if (Input.GetButton("Right") && !rightCollider.foundWall)
            {
                transform.position = new Vector3(transform.position.x + unitMovement, transform.position.y, transform.position.z);
                currentCooldownMovement = cooldownMovement;
            }
        }
        else
        {
            currentCooldownMovement -= Time.deltaTime;
        }
    }
}
