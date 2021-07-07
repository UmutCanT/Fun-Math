using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreControl : MonoBehaviour
{
    //ECScoresText
    public Text easyScoreEC, mediumScoreEC, hardScoreEC,
    //PMScoresText
                easyScorePM, mediumScorePM, hardScorePM,
    //HScoresText
                easyScoreH, mediumScoreH, hardScoreH;

    // Start is called before the first frame update
    void Start()
    {
        //EC Scores
        easyScoreEC.text = "Easy " + PrefSystem.GetEasyScore();
        mediumScoreEC.text = "Medium " + PrefSystem.GetMediumScore();
        hardScoreEC.text = "Hard " + PrefSystem.GetHardScore();

        //PM Scores
        easyScorePM.text = "Easy 50/" + PmPrefSystem.GetEasyPmScore();
        mediumScorePM.text = "Medium 70/" + PmPrefSystem.GetMediumPmScore();
        hardScorePM.text = "Hard 100/" + PmPrefSystem.GetHardPmScore();

        //H Scores
        easyScoreH.text = "Easy 50/" + HPrefSystem.GetEasyHScore();
        mediumScoreH.text = "Medium 70/" + HPrefSystem.GetMediumHScore();
        hardScoreH.text = "Hard 100/" + HPrefSystem.GetHardHScore();
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
