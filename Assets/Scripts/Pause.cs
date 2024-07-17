using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject volumeMenu;
    public static bool isPaused;

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
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        volumeMenu.SetActive(false);
        Time.timeScale = 1f; // Set the time scale back to normal
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

}
