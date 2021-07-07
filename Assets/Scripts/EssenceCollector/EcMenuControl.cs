using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EcMenuControl : MonoBehaviour
{
    public static bool gameIsPaused = false;

    public GameObject pausePanel;
    public GameObject playerUI;
    public GameObject gameOverPanel;
    public GameObject pauseButton;

    // Start is called before the first frame update
    void Start()
    {
        Resume();
        gameOverPanel.SetActive(false);        
        OpenUI();
    }

    public void BackToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void Replay()
    {
        SceneManager.LoadScene("EssenceCollector");
    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true);
        pauseButton.SetActive(false);
        FindObjectOfType<EcScore>().EndScore();
        CloseUI();
    }

    void OpenUI()
    {
        playerUI.SetActive(true);
        pauseButton.SetActive(true);
    }

    void CloseUI()
    {
        playerUI.SetActive(false);
    }

    public void Resume()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    public void Pause()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }
}
