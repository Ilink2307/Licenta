using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowObj : BaseInteractable
{
    public GameObject object1;
    void Start()
    {
        object1.SetActive(false);
    }

    public override void Interact()
    {
        object1.SetActive(true);
    }

    void Update()
    {
        
    }
}
