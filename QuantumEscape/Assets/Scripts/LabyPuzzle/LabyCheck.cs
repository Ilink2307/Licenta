using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LabyCheck : EventTrigger
{
    public override void OnPointerEnter(PointerEventData data)
    {
        gameObject.SetActive(false);
    }
}