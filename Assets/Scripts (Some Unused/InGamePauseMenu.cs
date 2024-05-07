using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGamePauseMenu : MonoBehaviour
{
    public GameObject inGamePause;
    public static bool pausedGame = false;

    public void ResumeGame()
    {
        inGamePause.SetActive(false);
        Time.timeScale = 1f;
        pausedGame = false;
    }
    private void PausedGame()
    {
        inGamePause.SetActive(true);
        Time.timeScale = 0f;
        pausedGame = true;
    }

    public void ReturnToMM()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Debug.Log("quit works?");
        Application.Quit();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pausedGame)
            {
                ResumeGame();
            }
            else
            {
                PausedGame();
            }
        }
    }



}
