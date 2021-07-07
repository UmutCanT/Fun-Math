using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MathProblems
{    
    public int firstNumber;
    public int secondNumber;
    public MathOperations operation;
    public int[] answers;
    public int correctAnswer;

    [Range(0, 3)]
    public int correctEssence; //index of correct essence
}
public enum MathOperations
{
    Addition,
    Subtraction,
    Multiplication,
    Division
}
