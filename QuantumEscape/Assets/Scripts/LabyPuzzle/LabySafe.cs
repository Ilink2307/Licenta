using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class LabySafe : EventTrigger
{
    public Vector2 mouseSafePos;

    public override void OnPointerEnter(PointerEventData data)
    {
        mouseSafePos = new Vector2(Mouse.current.position.x.value, Mouse.current.position.y.value);
    }
}