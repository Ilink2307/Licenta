using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolarizationManager : MonoBehaviour
{
    public static PolarizationManager instance;

    public SnapPoint[] snapPoints; // all snap points in the scene
    public GameObject[] objectsToToggle; // Objects that need to appear/disappear based on the snap points

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    public void CheckSnapPoints()
    {
        foreach (SnapPoint snapPoint in snapPoints)
        {
            if (snapPoint.isOccupied)
            {
                // Enable objects related to this snap point
                foreach (GameObject obj in snapPoint.objectsToEnable)
                {
                    obj.SetActive(true);
                }
                foreach (GameObject obj in snapPoint.objectsToDisable)
                {
                    obj.SetActive(false);
                }
            }
            else
            {
                // Disable objects related to this snap point
                foreach (GameObject obj in snapPoint.objectsToEnable)
                {
                    obj.SetActive(false);
                }
                foreach (GameObject obj in snapPoint.objectsToDisable)
                {
                    obj.SetActive(true);
                }
            }
        }
    }

    public void ResetObjects()
    {
        foreach (SnapPoint snapPoint in snapPoints)
        {
            // Disable objects related to this snap point
            foreach (GameObject obj in snapPoint.objectsToEnable)
            {
                obj.SetActive(false);
            }
            // Enable objects related to this snap point
            foreach (GameObject obj in snapPoint.objectsToDisable)
            {
                obj.SetActive(true);
            }
        }
    }
}

