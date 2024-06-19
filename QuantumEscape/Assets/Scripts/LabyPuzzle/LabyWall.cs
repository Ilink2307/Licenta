using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class LabyWall : EventTrigger
{
    public LabySafe labySafe;
    public Vector2 teleportPosition;

    public override void OnPointerEnter(PointerEventData data)
    {
        Debug.Log("Teleported");
        Mouse.current.WarpCursorPosition(labySafe.mouseSafePos);
        //Mouse.current.WarpCursorPosition(teleportPosition);
    }
}