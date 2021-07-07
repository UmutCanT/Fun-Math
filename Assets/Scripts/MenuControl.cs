using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour
{
    public GameObject quitPanel;

    public void StartEssenceCollector()
    {
        SceneManager.LoadScene("EssenceCollector");
    }

    public void StartPotionMaker()
    {
        SceneManager.LoadScene("PotionMaker");
    }

    public void StartHunter()
    {
        SceneManager.LoadScene("Hunter");
    }

    public void OpenSettingsMenu()
    {
        SceneManager.LoadScene("Settings");
    }

    public void OpenHighScores()
    {
        SceneManager.LoadScene("HighScores");
    }


    // Start is called before the first frame update
    void Start()
    {
        ContinueToPlay();

        //Seeting default difficulty 
        if (!PrefSystem.CheckDiffRecord())
        {
            PrefSystem.SetMediumDiff(1);
        }

        if (!PmPrefSystem.CheckDiffRecord())
        {
            PmPrefSystem.SetMediumPmDiff(1);
        }

        if (!HPrefSystem.CheckDiffRecord())
        {
            HPrefSystem.SetMediumHDiff(1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        ApplicationQuit();
    }

    private void ApplicationQuit()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            quitPanel.SetActive(true);
        }
    }
    public void ContinueToPlay()
    {
        quitPanel.SetActive(false);
    }

    public void QuitTheGame()
    {
        Application.Quit();
    }
}
