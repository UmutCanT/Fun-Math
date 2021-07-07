using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Questions
{
    public string questions;
    public string[] answers;
    public string correctAnswer;

    [Range(0, 1)]
    public int correctPotion; //index of correct potion
}
