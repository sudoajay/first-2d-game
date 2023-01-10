using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePlayUIController : MonoBehaviour
{
    public static bool GameIsPaused = false;


    public GameObject pauseMenuUI;

    public GameObject pauseButton;

    public GameObject resumeButton;

    // Start is called before the first frame update
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }

        if(!(Player.isAlive)) 
            gameStop();
    }

    public void gamePaused()
    {
        Pause();
    }

     private void Pause()
    {
        pauseMenuUI.SetActive(true);
        pauseButton.SetActive(false);
        Time.timeScale = 0f;
        GameIsPaused = true;

    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        pauseButton.SetActive(true);
        Time.timeScale = 1f;
        GameIsPaused = false;
        Player.isAlive = true;
    }

   

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        if (GameIsPaused)
        {
            Time.timeScale = 1f;
            GameIsPaused = false;
            Player.isAlive = true;
            resumeButton.SetActive(true);

        }
    }

    public void Home()
    {
        SceneManager.LoadScene("MainMenu");
        if (GameIsPaused)
        {
            Time.timeScale = 1f;
            GameIsPaused = false;
            Player.isAlive = true;
            resumeButton.SetActive(true);

        }
    }

    private void gameStop(){
        Time.timeScale = 0f;
        GameIsPaused = true;
        resumeButton.SetActive(false);

    }
}
