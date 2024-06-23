using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public GameObject object1;
    public GameObject object2;
    public Color targetColor;
    public KeyCode interactionKey = KeyCode.E; // Key to interact with the object

    private TMP_Text object1TextComponent;
    private TMP_Text object2TextComponent;

    void Start()
    {
        object1TextComponent = object1.GetComponent<TMP_Text>();
        object2TextComponent = object2.GetComponent<TMP_Text>();
    }

    void Update()
    {
        if (Input.GetKeyDown(interactionKey))
        {
            CheckColorsAndDisappear();
        }
    }

    void CheckColorsAndDisappear()
    {
        if (object1TextComponent != null && object2TextComponent != null)
        {
            if (object1TextComponent.color == targetColor && object2TextComponent.color == targetColor)
            {
                gameObject.SetActive(false);
            }
        }
    }
}
