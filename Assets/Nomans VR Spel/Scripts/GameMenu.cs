using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    public GameObject MenuUI;
    public bool activateMenuUI = true;
    public string sceneName;

    private bool isPaused = false;

    void Start()
    {
        DisplayUI();
    }

    public void ExitGame()
    {
        Debug.Log("Quit game");
        Application.Quit();
    }

    public void ReturnMenu()
    {
        Debug.Log("Returning to Menu");
        SceneManager.LoadScene(sceneName);
    }

    public void MenuPressed(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    private void PauseGame()
    {
        isPaused = true;
        DisplayUI();
        Time.timeScale = 0f;
    }

    private void ResumeGame()
    {
        isPaused = false;
        DisplayUI();
        Time.timeScale = 1f;
    }

    public void DisplayUI()
    {
        MenuUI.SetActive(isPaused);
    }
}