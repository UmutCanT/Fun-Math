using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HScore : MonoBehaviour
{

    int score = 0;
    int highestScore = 0;
    bool continueScore = true;

    [SerializeField]
    Text gameOverScoreText = default;

    /// <summary>
    /// Updating the score according to difficulty
    /// </summary>
    public void HUpdateScore()
    {
        if (continueScore)
        {
            if (HPrefSystem.GetEasyHDiff() == 1)
            {
                score += 5;
            }

            if (HPrefSystem.GetMediumHDiff() == 1)
            {
                score += 7;
            }

            if (HPrefSystem.GetHardHDiff() == 1)
            {
                score += 10;
            }
        }
    }

    /// <summary>
    /// Endscore according to difficulty
    /// </summary>
    public void HEndScore()
    {
        if (HPrefSystem.GetEasyHDiff() == 1)
        {
            highestScore = HPrefSystem.GetEasyHScore();
            if (score > highestScore)
            {
                HPrefSystem.SetEasyHScore(score);
            }
        }

        if (HPrefSystem.GetMediumHDiff() == 1)
        {
            highestScore = HPrefSystem.GetMediumHScore();
            if (score > highestScore)
            {
                HPrefSystem.SetMediumHScore(score);
            }
        }

        if (HPrefSystem.GetHardHDiff() == 1)
        {
            highestScore = HPrefSystem.GetHardHScore();
            if (score > highestScore)
            {
                HPrefSystem.SetHardHScore(score);
            }
        }

        continueScore = false;
        gameOverScoreText.text = "Score " + score.ToString();
    }
}
