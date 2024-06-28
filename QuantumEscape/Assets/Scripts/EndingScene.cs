using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingScene : BaseInteractable
{
    public override void Interact()
    {
        SceneManager.LoadScene("SpaceShipEnding");
    }
}
