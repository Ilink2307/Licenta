using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolarizationManager : MonoBehaviour
{
    public static PolarizationManager instance;

    public SnapPoint[] snapPoints; // Array of all snap points in the scene
    public GameObject[] objectsToToggle; // Objects that need to appear/disappear based on the snap points

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void CheckSnapPoints()
    {
        bool allSnapped = true;
        foreach (SnapPoint snapPoint in snapPoints)
        {
            if (!snapPoint.isOccupied)
            {
                allSnapped = false;
                break;
            }
        }

        foreach (GameObject obj in objectsToToggle)
        {
            obj.SetActive(allSnapped);
        }
    }
}
