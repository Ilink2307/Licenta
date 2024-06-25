using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapPoint : MonoBehaviour
{
    public Transform snapPosition; // Position where the object should snap to
    public bool isOccupied = false; // Check if the snap point is occupied
    public GameObject[] objectsToEnable; // Objects to enable when this snap point is occupied
    public GameObject[] objectsToDisable;
}
