using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseMenu : MonoBehaviour
{
    public static bool gamePaused = false;
    public GameObject pauseUI;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gamePaused == true)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseUI.SetActive(false);
        Time.timeScale = 1f; //sets game time back to normal
        gamePaused = false;
    }

    void Pause()
    {
        pauseUI.SetActive(true);
        Time.timeScale = 0f; //stops time while game is paused
        gamePaused = true;
    }

    public void LoadMain ()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("mainMenu");

    }

    public void quitGame()
    {
        Debug.Log("Game ending");
        Application.Quit();
    }
}
