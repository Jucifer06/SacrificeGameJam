using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Pause : MonoBehaviour
{
    public Canvas pauseCanvas;
    public Canvas mainCanvas;
    public GameObject pauseButton;
    public GameObject unpauseButton;
    private bool isPaused;


    private void Start()
    {
        isPaused = false;
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                PlayGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0;

        pauseCanvas.gameObject.SetActive(true);
        mainCanvas.gameObject.SetActive(false);

        pauseButton.SetActive(false);
        unpauseButton.SetActive(true);
    }

    public void PlayGame()
    {
        isPaused = false;
        Time.timeScale = 1;

        pauseCanvas.gameObject.SetActive(false);
        mainCanvas.gameObject.SetActive(true);

        pauseButton.SetActive(true);
        unpauseButton.SetActive(false);
    }

    public void startTime() {
        Time.timeScale = 1;
    }
    public void pauseTime() {
        Time.timeScale = 0;
    }
}
