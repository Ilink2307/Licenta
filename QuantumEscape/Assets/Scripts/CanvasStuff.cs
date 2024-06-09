using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasStuff : MonoBehaviour
{
    private OpenMinigame openMinigame;

    void Start()
    {
        openMinigame = FindObjectOfType<OpenMinigame>();
    }

    public void ExitCanvas()
    {
        if (openMinigame != null)
        {
            openMinigame.CloseCanvas();
        }
    }
}
