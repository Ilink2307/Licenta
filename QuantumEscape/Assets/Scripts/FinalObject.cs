using UnityEngine;

public class FinalObject : MonoBehaviour
{
    public GameObject objectToAppear;

    private void Start()
    {
        
        objectToAppear.SetActive(false);    
    }
    public void ShowObject()
    {
        if (objectToAppear != null)
        {
            objectToAppear.SetActive(true);
        }
    }
}