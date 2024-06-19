using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;

public class LabyrinthManager : MonoBehaviour
{
    public TextMeshProUGUI counterText; // Reference to the counter Text element
    public GameObject messageBackground; // Reference to the message background image
    public TextMeshProUGUI messageText; // Reference to the message Text element
    public Button resetButton; // Reference to the reset Button
    public GameObject labyrinth; // Reference to the labyrinth GameObject
    private int falseWallCount = 0;
    private List<GameObject> initialFakeWalls = new List<GameObject>();

    private void OnEnable()
    {
        LabyCheck.OnFalseWallChecked += IncrementFalseWallCount;
    }

    private void OnDisable()
    {
        LabyCheck.OnFalseWallChecked -= IncrementFalseWallCount;
    }

    private void Start()
    {
        messageBackground.SetActive(false); // Hide message background initially
        resetButton.onClick.AddListener(ResetCanvas); // Add listener for reset button
        StoreInitialFakeWalls(); // Store the initial state of the fake walls
    }

    private void StoreInitialFakeWalls()
    {
        // Find all LabyCheck components in the labyrinth and store their game objects
        foreach (LabyCheck labyCheck in labyrinth.GetComponentsInChildren<LabyCheck>())
        {
            initialFakeWalls.Add(labyCheck.gameObject);
        }
    }

    private void IncrementFalseWallCount()
    {
        falseWallCount++;
        UpdateCounterText();
        CheckCounterLimit();
    }

    private void UpdateCounterText()
    {
        counterText.text = "False Walls Checked: " + falseWallCount;
        Debug.Log("Updated counterText to: " + counterText.text); // Add debug log
    }

    private void CheckCounterLimit()
    {
        if (falseWallCount > 10)
        {
            messageBackground.SetActive(true); // Show the message background
        }
    }

    private void ResetCanvas()
    {
        falseWallCount = 0;
        UpdateCounterText();
        messageBackground.SetActive(false); // Hide the message background

        // Reactivate all initial fake walls
        foreach (GameObject fakeWall in initialFakeWalls)
        {
            fakeWall.SetActive(true);
        }

        // Additional reset logic, if any, can go here
    }
}
