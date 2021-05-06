using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EcController : MonoBehaviour
{

    // instance
    public static EcController instance;

    void Awake()
    {
        instance = this;
    }

    [SerializeField]
    GameObject[] essencePrefab = default;

    List<GameObject> essences = new List<GameObject>();

    Vector2 essencePosition;

    public List<MathProblems> mProblemsList = new List<MathProblems>();

    public MathProblems mathProblems;

    //current problem the player needs to solve
    public int curProblem;

    Countdown countdown;

    [SerializeField]
    GameObject playerPrefab = default; // player object

    // Start is called before the first frame update
    void Start()
    {       
        countdown = gameObject.AddComponent<Countdown>();
        countdown.TotalTime = 8;
        countdown.RunCountdown();
        RandomProblemGenerator(mathProblems);
        SetProblems(0);        
    }

    // Update is called once per frame
    void Update()
    {
        if (countdown.Finished)
        {
            SpawnEssence();
            countdown.RunCountdown();
            RandomProblemGenerator(mathProblems);
        }
    }

    void SetProblems(int problem)
    {
        curProblem = problem;
        EcUI.instance.SetProblemText(mProblemsList[curProblem]);
    }

    void GameOver()
    {
        //If the player healt is 0 game over.
    }

    void WrongEssence()
    {
        Debug.Log("Wrong");

        if (mProblemsList.Count - 1 == curProblem)
            Destroy(GameObject.FindGameObjectWithTag("Essence"));
        else
            SetProblems(curProblem + 1);
    }

    void CorrectEssence()
    {
        Debug.Log("Correct");

        if (mProblemsList.Count - 1 == curProblem)
            Destroy(GameObject.FindGameObjectWithTag("Essence"));
        else
            SetProblems(curProblem + 1);
    }

    // called when the player enters a tube
    public void OnCollectingEssence(int essenceID)
    {
        // did they enter the correct tube?
        if (essenceID == mProblemsList[curProblem].correctEssence)
        {
            CorrectEssence();
        }
        else
        {
            WrongEssence();
        }
    }

    /// <summary>
    /// Spawning set of essences
    /// </summary>
    void SpawnEssence()
    {
        essencePosition = new Vector2(-3 * ScreenSizeManager.instance.Witdh / 4, ScreenSizeManager.instance.Height);
        for (int i = 0; i < 4; i++)
        {
            GameObject essence = Instantiate(essencePrefab[i], essencePosition, Quaternion.identity);
            essence.GetComponentInChildren<Text>().text = EcUI.instance.SetAnswerText(mProblemsList[curProblem], i);
            essence.GetComponent<Essence>().Falling = true;
            essences.Add(essence);           
            EssencePositions(i);           
        }
    }

    /// <summary>
    /// Changing essence horizontal position 
    /// </summary>
    /// <param name="horizontal"></param>
    void EssencePositions(int horizontal)
    {
        switch (horizontal)
        {
            case 0:
                essencePosition.x = -ScreenSizeManager.instance.Witdh / 4;
                break;
            case 1:
                essencePosition.x = ScreenSizeManager.instance.Witdh / 4;
                break;
            case 2:
                essencePosition.x = 3 * ScreenSizeManager.instance.Witdh / 4;
                break;
            case 3:
                essencePosition.x = -3 * ScreenSizeManager.instance.Witdh / 4;
                break;
            default:
                break;
        }
    }

    void RandomProblemGenerator(MathProblems mathProblems)
    {       
        int firstNumber = Random.Range(1,100);
        int secondNumber = Random.Range(1, 100);
        int correctAnswer = 0;

        MathOperations operation = (MathOperations)Random.Range(0,3);
        switch (operation)
        {
            case MathOperations.Addition:
                correctAnswer = firstNumber + secondNumber;
                mathProblems.firstNumber = firstNumber;
                mathProblems.secondNumber = secondNumber;
                break;
            case MathOperations.Subtraction:
                if(firstNumber >= secondNumber)
                {
                    correctAnswer = firstNumber - secondNumber;
                    mathProblems.firstNumber = firstNumber;
                    mathProblems.secondNumber = secondNumber;
                }
                else
                {
                    correctAnswer = secondNumber - firstNumber;
                    mathProblems.firstNumber = secondNumber;
                    mathProblems.secondNumber = firstNumber;
                }
                break;
            case MathOperations.Multiplication:
                correctAnswer = firstNumber * secondNumber;
                mathProblems.firstNumber = firstNumber;
                mathProblems.secondNumber = secondNumber;
                break;
            case MathOperations.Division:
                if(firstNumber >= secondNumber)
                {
                    correctAnswer = firstNumber / secondNumber;
                    mathProblems.firstNumber = firstNumber;
                    mathProblems.secondNumber = secondNumber;
                }
                else
                {
                    correctAnswer = secondNumber / firstNumber;
                    mathProblems.firstNumber = secondNumber;
                    mathProblems.secondNumber = firstNumber;
                }              
                break;
        }
        mathProblems.operation = operation;
        mathProblems.answers = new int[4];
        AssignAnswers(mathProblems.answers, correctAnswer);
        ArrayShuffler(mathProblems.answers);
        mathProblems.correctEssence = System.Array.IndexOf(mathProblems.answers, correctAnswer);
        Debug.Log(mathProblems.correctEssence);
        mProblemsList.Add(mathProblems);
    }

    void AssignAnswers(int[] answer, int correctAnswer)
    {
        int wrongAnswer1 = 0;
        int wrongAnswer2 = 0;
        int wrongAnswer3 = 0;

        if(correctAnswer <= 10)
        {
            wrongAnswer1 = correctAnswer + 3;
            wrongAnswer2 = correctAnswer + 2;
            wrongAnswer3 = correctAnswer + 5;

        }
        else if(correctAnswer > 10 && correctAnswer <= 100)
        {
            wrongAnswer1 = correctAnswer + 10;
            wrongAnswer2 = correctAnswer - 10;
            wrongAnswer3 = correctAnswer + 12;
        }
        else if(correctAnswer > 100)
        {
            wrongAnswer1 = correctAnswer - 20;
            wrongAnswer2 = correctAnswer + 28;
            wrongAnswer3 = correctAnswer - 18;
        }

        answer[0] = correctAnswer;
        answer[1] = wrongAnswer1;
        answer[2] = wrongAnswer2;
        answer[3] = wrongAnswer3;
    }

    void ArrayShuffler(int[] array)
    {       
        for (int i = 0; i < array.Length; i++)
        {
            int temp = array[i];
            int randomIndex = Random.Range(0, array.Length);
            array[i] = array[randomIndex];
            array[randomIndex] = temp;            
        }
    }

    void Addition()
    {

    }

    void Substraction()
    {

    }

    void Multiplication()
    {

    }

    void Division()
    {

    }
}
