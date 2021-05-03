using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour
{
    public void StartEssenceCollector()
    {
        SceneManager.LoadScene("EssenceCollector");
    }

    public void StartPotionMaker()
    {
        SceneManager.LoadScene("EssenceCollector");
    }

    public void StartHunter()
    {
        SceneManager.LoadScene("EssenceCollector");
    }

    public void OpenSettingsMenu()
    {
        SceneManager.LoadScene("SettingsMenu");
    }

    public void OpenHighScores()
    {
        SceneManager.LoadScene("HighScores");
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
