using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class LabyWall : EventTrigger
{
    public LabySafe labySafe;

    public override void OnPointerEnter(PointerEventData data)
    {
        Debug.Log("Teleported");
        Mouse.current.WarpCursorPosition(labySafe.mouseSafePos);
    }
}