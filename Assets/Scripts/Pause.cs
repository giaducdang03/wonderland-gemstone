using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject volumeMenu;
    public static bool isPaused = false;

    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
        volumeMenu.SetActive(false);
    }

    // Update is called once per frame
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
        if (pauseMenu != null)
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0f; // Pause the game
            isPaused = true;
        }
        else
        {
            Debug.LogWarning("Pause menu is not assigned in the Inspector.");
        }
    }

    public void ResumeGame()
    {
        /*            pauseMenu.SetActive(false);
                    volumeMenu.SetActive(false);
                    Time.timeScale = 1f; // set the time scale back to normal
                    isPaused = false;*/
        if (pauseMenu != null)
        {
            pauseMenu.SetActive(false);
        }

        if (volumeMenu != null)
        {
            volumeMenu.SetActive(false);
        }

        Time.timeScale = 1f; // Resume the game
        isPaused = false;

    }

    public void OpenVolumeMenu()
    {
        /*            volumeMenu.SetActive(true);
                    pauseMenu.SetActive(false);*/
        if (volumeMenu != null && pauseMenu != null)
        {
            volumeMenu.SetActive(true);
            pauseMenu.SetActive(false);
        }
        else
        {
            Debug.LogWarning("Volume menu or pause menu is not assigned in the Inspector.");
        }
    }

    public void CloseVolumeMenu()
    {
        /*            volumeMenu.SetActive(false);
                    pauseMenu.SetActive(true);*/

        if (volumeMenu != null && pauseMenu != null)
        {
            volumeMenu.SetActive(false);
            pauseMenu.SetActive(true);
        }
        else
        {
            Debug.LogWarning("Volume menu or pause menu is not assigned in the Inspector.");
        }
    }

}
