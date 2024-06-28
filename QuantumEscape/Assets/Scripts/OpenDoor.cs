using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OpenDoor : BaseInteractable
{
    public GameObject object1;
    public GameObject object2;
    public Color targetColor;

    private SpriteRenderer object1Renderer;
    private SpriteRenderer object2Renderer;

    void Start()
    {
        object1Renderer = object1.GetComponent<SpriteRenderer>();
        object2Renderer = object2.GetComponent<SpriteRenderer>();
        targetColor = object1Renderer.color;

    }

    public override void Interact()
    {
        CheckColorsAndDisappear();
    }

    private void Update()
    {
        
    }
    void CheckColorsAndDisappear()
    {
        if (object1Renderer.color != targetColor && object2Renderer.color != targetColor)
        {
            gameObject.SetActive(false);
        }
    }
}
