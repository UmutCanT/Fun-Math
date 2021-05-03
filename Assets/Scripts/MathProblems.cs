using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//All values can be seen at the inspector
[System.Serializable]
public class MathProblems
{    
    public float firstNumber;
    public float secondNumber;
    public MathOperations operation;
    public int[] answers;
    
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
