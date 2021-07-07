using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PmController : MonoBehaviour
{
    // instance
    public static PmController instance;

    void Awake()
    {
        instance = this;
    }

    public Questions[] questions;      // list of all questions
    int curQuestion;          // current question the player needs to answer
    public float totalAnsweringTime;    // time allowed to answer each question
    public float remainingTime;     // time remaining for the current problem

    public PmPlayer player; // player object

    bool isGameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        TimeSettings();
        SetQuestion(0);
    }

    // Update is called once per frame
    void Update()
    {
        remainingTime -= Time.deltaTime;

        // has the remaining time ran out?
        if (remainingTime <= 0.0f)
        {
            GameOver(false);
        }
    }

    void SetQuestion(int question)
    {
        curQuestion = question;
        remainingTime = totalAnsweringTime;
        PmUI.instance.SetQuestionText(questions[curQuestion]);
    }

    public void GameOver(bool result)
    {
        isGameOver = true;
        FindObjectOfType<PmMenuControl>().GameOver(result);
    }

    void WrongAnswer()
    {
        player.GetComponent<PmPlayer>().Damage(10);
        if (questions.Length - 1 == curQuestion)
        {
            Win();
        }
        else
        {
            SetQuestion(curQuestion + 1);
        }                 
    }

    void CorrectAnswer()
    {
        FindObjectOfType<PmScore>().PmUpdateScore();
        if (questions.Length - 1 == curQuestion)
        {
            Win();
        }
        else
            SetQuestion(curQuestion + 1);
        
    }

    // called when the player collecting the essence
    public void OnSelectingPotion(int potionID)
    {
        if (!isGameOver)
        {
            if (potionID == questions[curQuestion].correctPotion)
            {
                CorrectAnswer();
            }
            else
            {
                WrongAnswer();
            }
        }
    }

    void Win()
    {
        Time.timeScale = 0.0f;
        GameOver(true);
    }

    void TimeSettings()
    {
        if (PmPrefSystem.GetEasyPmDiff() == 1)
        {
            totalAnsweringTime = 10f;
        }
        if (PmPrefSystem.GetMediumPmDiff() == 1)
        {
            totalAnsweringTime = 5f;
        }
        if (PmPrefSystem.GetHardPmDiff() == 1)
        {
            totalAnsweringTime = 3f;
        }
    }
}
