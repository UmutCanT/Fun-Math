using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PmUI : MonoBehaviour
{
    public static PmUI instance;

    void Awake()
    {
        instance = this;
    }

    public Text problemText;                // text that displays the question
    public Text[] answersTexts;             // array of the 2 answers texts

    public Image remainingTimeDial;         // remaining time image with radial fill
    private float remainingTimeDialRate;    // 1.0 / time per problem

    // Start is called before the first frame update
    void Start()
    {
        remainingTimeDialRate = 1.0f / PmController.instance.totalAnsweringTime;
    }

    // Update is called once per frame
    void Update()
    {
        remainingTimeDial.fillAmount = remainingTimeDialRate * PmController.instance.remainingTime;
    }

    public void SetQuestionText(Questions questions)
    {
        // set the problem text to display the question
        problemText.text = questions.questions;

        // set the answers texts to display the correct and incorrect answers
        for (int index = 0; index < answersTexts.Length; ++index)
        {
            answersTexts[index].text = questions.answers[index];
        }
    }
}
