using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool IsPause = false;
    public GameObject pauseMenuUI;
    public GameObject GamePoint;
    public GameObject Controll;

    public void PauseGame()
    {
        IsPause = true;
        pauseMenuUI.SetActive(true);
        GamePoint.SetActive(false);
        Controll.SetActive(false);

        Time.timeScale = 0f;

    }

    public void Resume()
    {
        IsPause = false;
        pauseMenuUI.SetActive(false);
        GamePoint.SetActive(true);
        Controll.SetActive(true);
        Time.timeScale = 1f;

    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1f;
    }

}
