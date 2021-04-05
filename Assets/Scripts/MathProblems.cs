using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//All values can be seen at the inspector
[System.Serializable]
public class MathProblems
{
    public enum MathOperations
    {
        Addition,
        Subtraction,
        Multiplication,
        Division
    }

    public float firstNumber;
    public float secondNumber;
    public float thirdNumber;
    public float fourthNumber;
    public MathOperations operation;
    public float[] answers;

    [Range(0, 3)]
    public int correctEssence; //index of correct essence
    public int correctAnswer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
