using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EcUI : MonoBehaviour
{
    public static EcUI instance;

    void Awake()
    {
        instance = this;
    }

    /// <summary>
    /// Setting the problem text on the player
    /// </summary>
    /// <param name="mProblem"></param>
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

        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMoves>().Problem = mProblem.firstNumber + operatorText + mProblem.secondNumber;      
    }

    /// <summary>
    /// Setting the answer on the essence according to index number
    /// </summary>
    /// <param name="mProblem"></param>
    /// <param name="index"></param>
    public string SetAnswerText(MathProblems mProblem, int index)
    {
        Debug.Log(mProblem.answers[index]);
        return mProblem.answers[index].ToString();       
    }
}