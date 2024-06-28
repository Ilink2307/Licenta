using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Canvas mainMenuCanvas;
    public Canvas optionsCanvas;

    void Start()
    {
        ShowMainMenu();
    }
    public void ShowMainMenu()
    {
        mainMenuCanvas.gameObject.SetActive(true);
        optionsCanvas.gameObject.SetActive(false);
    }

    public void ShowOptions()
    {
        mainMenuCanvas.gameObject.SetActive(false);
        optionsCanvas.gameObject.SetActive(true);
    }
    public void StartGame()
    {
        SceneManager.LoadScene("TestScene");
    }

    public void QuitGame()
    {
        // Quit the game
        Application.Quit();
        // If running in the editor
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
