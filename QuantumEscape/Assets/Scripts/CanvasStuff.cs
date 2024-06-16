using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasStuff : MonoBehaviour
{
    public OpenMinigame openMinigame;

    void Start()
    {
        
    }

    public void CloseCanvas()
    {
        if (openMinigame != null)
        {
            openMinigame.CloseCanvas();
        }
    }
}
