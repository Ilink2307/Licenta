using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabyEngine : MonoBehaviour
{
    public GameObject resetSheet;
    public float resetRate = 0.001f;
    public bool activeStatus = false;

    private void Update()
    {
        StartCoroutine(Change());
    }

    IEnumerator Change()
    {
        resetSheet.SetActive(activeStatus);
        activeStatus = !activeStatus;
        yield return new WaitForSeconds(resetRate);
    }
}
