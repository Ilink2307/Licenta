using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipMovement : MonoBehaviour
{
    public float speed;
    public int xTeleportFrom;
    public int xTeleportTo;

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x >= xTeleportFrom)
        {
            transform.position = new Vector3(xTeleportTo, transform.position.y, transform.position.z);
        }
        transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
    }
}
