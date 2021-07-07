using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EcScore : MonoBehaviour
{
    int score = 0;
    int highestScore = 0;
    bool continueScore = true;

    [SerializeField]
    Text scoreText = default;

    [SerializeField]
    Text gameOverScoreText = default;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = score.ToString();
    }

    /// <summary>
    /// Update the score according to difficulty
    /// </summary>
    public void UpdateScore()
    {
        if (continueScore)
        {
            if (PrefSystem.GetEasyDiff() == 1)
            {
                score += 5;
                scoreText.text = score.ToString();
            }

            if (PrefSystem.GetMediumDiff() == 1)
            {
                score += 7;
                scoreText.text = score.ToString();
            }

            if (PrefSystem.GetHardDiff() == 1)
            {
                score += 10;
                scoreText.text = score.ToString();
            }           
        }
    }

    /// <summary>
    /// Ending score according to difficulty
    /// </summary>
    public void EndScore()
    {
        if (PrefSystem.GetEasyDiff() == 1)
        {
            highestScore = PrefSystem.GetEasyScore();
            if (score > highestScore)
            {
                PrefSystem.SetEasyScore(score);
            }
        }

        if (PrefSystem.GetMediumDiff() == 1)
        {
            highestScore = PrefSystem.GetMediumScore();
            if (score > highestScore)
            {
                PrefSystem.SetMediumScore(score);
            }
        }

        if (PrefSystem.GetHardDiff() == 1)
        {
            highestScore = PrefSystem.GetHardScore();
            if (score > highestScore)
            {
                PrefSystem.SetHardScore(score);
            }
        }

        continueScore = false;
        gameOverScoreText.text = "Score " + score.ToString();
    }
}
