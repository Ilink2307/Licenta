using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChecker : MonoBehaviour
{
    public GameObject cable1; 
    public GameObject cable2; 
    public GameObject cable3;
    public Color requiredColor = Color.blue; // The specific color to check

    public GameObject[] objectsToChange; // Array of objects to change color
    public Color changeToColor = Color.blue; // Color to change to if the conditions are met

    private void Update()
    {
        CheckColorsAndChange();
    }

    private void CheckColorsAndChange()
    {
        if (IsColorMatch(cable1, requiredColor) && IsColorMatch(cable2, requiredColor) && IsColorMatch(cable3, requiredColor))
        {
            ChangeColors(objectsToChange, changeToColor);
        }
    }

    private bool IsColorMatch(GameObject obj, Color color)
    {
        if (obj != null)
        {
            SpriteRenderer renderer = obj.GetComponent<SpriteRenderer>();
            if (renderer != null)
            {
                // Comparing the material's color to the specified color
                return renderer.color == color;
            }
            else
            {
                Debug.LogWarning("No Renderer found on the object: " + obj.name);
            }
        }
        else
        {
            Debug.LogWarning("Object reference is not assigned.");
        }
        return false;
    }

    private void ChangeColors(GameObject[] objects, Color color)
    {
        foreach (GameObject obj in objects)
        {
            if (obj != null)
            {
                SpriteRenderer renderer = obj.GetComponent<SpriteRenderer>();
                if (renderer != null)
                {
                    renderer.color = color;
                }
                else
                {
                    Debug.LogWarning("No Renderer found on the object: " + obj.name);
                }
            }
            else
            {
                Debug.LogWarning("Object reference is not assigned.");
            }
        }
    }
}
