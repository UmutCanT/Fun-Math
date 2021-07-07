using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PmScore : MonoBehaviour
{

    int score = 0;
    int highestScore = 0;
    bool continueScore = true;

    [SerializeField]
    Text gameOverScoreText = default;

    //Updating score according to difficulty
    public void PmUpdateScore()
    {
        if (continueScore)
        {
            if (PmPrefSystem.GetEasyPmDiff() == 1)
            {
                score += 5;
            }

            if (PmPrefSystem.GetMediumPmDiff() == 1)
            {
                score += 7;
            }

            if (PmPrefSystem.GetHardPmDiff() == 1)
            {
                score += 10;
            }
        }
    }

    //Endscore according to difficulty
    public void PmEndScore()
    {
        if (PmPrefSystem.GetEasyPmDiff() == 1)
        {
            highestScore = PmPrefSystem.GetEasyPmScore();
            if (score > highestScore)
            {
                PmPrefSystem.SetEasyPmScore(score);
            }
        }

        if (PmPrefSystem.GetMediumPmDiff() == 1)
        {
            highestScore = PmPrefSystem.GetMediumPmScore();
            if (score > highestScore)
            {
                PmPrefSystem.SetMediumPmScore(score);
            }
        }

        if (PmPrefSystem.GetHardPmDiff() == 1)
        {
            highestScore = PmPrefSystem.GetHardPmScore();
            if (score > highestScore)
            {
                PmPrefSystem.SetHardPmScore(score);
            }
        }

        continueScore = false;
        gameOverScoreText.text = "Score " + score.ToString();
    }
}
