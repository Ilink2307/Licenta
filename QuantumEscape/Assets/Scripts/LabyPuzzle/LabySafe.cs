using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class LabySafe : EventTrigger
{
    public Vector2 mouseSafePos;

    public void SetSafePosition(Vector2 position)
    {
        mouseSafePos = position;
    }

    public override void OnPointerEnter(PointerEventData data)
    {
        SetSafePosition(new Vector2(Mouse.current.position.x.value, Mouse.current.position.y.value));
    }
}