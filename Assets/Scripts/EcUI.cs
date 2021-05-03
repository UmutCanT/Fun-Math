using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EcUI : MonoBehaviour
{
    public static EcUI instance;

    public Text problemText;                // text that displays the maths problem
    public Text[] answersTexts = default;             // array of the 4 answers texts

    GameObject essence;
    GameObject player;

    void Awake()
    {
        instance = this;
    }
    // sets the ship UI to display the new problem
    public void SetProblemText(MathProblems mProblem)
    {
        string operatorText = "";

        // convert the problem operator from an enum to an actual text symbol
        switch (mProblem.operation)
        {
            case MathOperations.Addition: operatorText = " + "; 
                break;
            case MathOperations.Subtraction: operatorText = " - "; 
                break;
            case MathOperations.Multiplication: operatorText = " x "; 
                break;
            case MathOperations.Division: operatorText = " ÷ "; 
                break; 
        }

        // set the problem text to display the problem

        problemText.text = mProblem.firstNumber + operatorText + mProblem.secondNumber;   

        // set the answers texts to display the correct and incorrect answers
        for (int index = 0; index < 4; ++index)
        {                      
            essence.GetComponent<Essence>().Answers = mProblem.answers[index].ToString();
        }
    }
}