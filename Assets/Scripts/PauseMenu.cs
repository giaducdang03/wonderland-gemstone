using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject volumeMenu;
    public static bool isPaused;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
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

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f; // pause the game by setting time scale to 0
        isPaused = true;
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        volumeMenu.SetActive(false);
        Time.timeScale = 1f; // set the time scale back to normal
        isPaused = false;
    }

    public void OpenVolumeMenu()
    {
        volumeMenu.SetActive(true);
        pauseMenu.SetActive(false);
    }

    public void CloseVolumeMenu()
    {
        volumeMenu.SetActive(false);
        pauseMenu.SetActive(true);
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("StartScene");
    }
}
