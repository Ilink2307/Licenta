using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LabyCheck : EventTrigger
{
    public static System.Action OnFalseWallChecked; // Add a static event
    public override void OnPointerEnter(PointerEventData data)
    {
        gameObject.SetActive(false);
        OnFalseWallChecked?.Invoke();
    }
}