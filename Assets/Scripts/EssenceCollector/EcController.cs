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

    [SerializeField]
    GameObject playerPrefab = default; // player prefab
    GameObject player;

    bool isGameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        SpawnPlayer();
        RandomProblemGenerator(mathProblems);
        SetProblems(0);
        SpawnEssence();
    }

    void SetProblems(int problem)
    {
        curProblem = problem;
        EcUI.instance.SetProblemText(mProblemsList[curProblem]);       
    }

    public void GameOver()
    {
        isGameOver = true;
        FindObjectOfType<EcMenuControl>().GameOver();
    }

    void WrongEssence()
    {
        RandomProblemGenerator(mathProblems);
        SetProblems(curProblem);
        player.GetComponent<EcPlayer>().Damage(10);
        mProblemsList.RemoveAt(1);
    }

    void CorrectEssence()
    {
        RandomProblemGenerator(mathProblems);
        SetProblems(curProblem);
        FindObjectOfType<EcScore>().UpdateScore();
        mProblemsList.RemoveAt(1);
    }

    // called when the player collecting the essence
    public void OnCollectingEssence(int essenceID)
    {
        if (!isGameOver)
        {
            if (essenceID == mProblemsList[curProblem].correctEssence)
            {
                CorrectEssence();
            }
            else
            {
                WrongEssence();
            }
            DestroyingEssences();
            SpawnEssence();
        }
    }

    // Spawning set of essences
    void SpawnEssence()
    {
        essencePosition = new Vector2(-3 * ScreenSizeManager.instance.Witdh / 4, ScreenSizeManager.instance.Height);
        for (int i = 0; i < 4; i++)
        {
            GameObject essence = Instantiate(essencePrefab[i], essencePosition, Quaternion.identity);
            essence.GetComponentInChildren<Text>().text = EcUI.instance.SetAnswerText(mProblemsList[curProblem], i);
            essence.GetComponent<Essence>().SettingID = i;
            essence.GetComponent<Essence>().Falling = true;
            essences.Add(essence);           
            EssencePositions(i);           
        }
    }

    void SpawnPlayer()
    {
        Vector2 playerPosition = new Vector2(0,0);
        Instantiate(playerPrefab, playerPosition, Quaternion.identity);
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Destroy other essences
    void DestroyingEssences()
    {
        GameObject[] essences = GameObject.FindGameObjectsWithTag("Essence");
        for (int i = 0; i < essences.Length; i++)
        {
            Destroy(essences[i]);
        }
    }

   
    // Changing essence horizontal position 
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
        int temp = 0;
        int correctAnswer = 0;

        MathOperations operation = (MathOperations)Random.Range(0,4);
        switch (operation)
        {
            case MathOperations.Addition:
                mathProblems.firstNumber = Random.Range(0, 100);
                mathProblems.secondNumber = Random.Range(0, 100);
                correctAnswer = mathProblems.firstNumber + mathProblems.secondNumber;                
                break;
            case MathOperations.Subtraction:
                mathProblems.firstNumber = Random.Range(0, 100);
                mathProblems.secondNumber = Random.Range(0, 100);
                if (mathProblems.firstNumber >= mathProblems.secondNumber)
                {
                    correctAnswer = mathProblems.firstNumber - mathProblems.secondNumber;                   
                }
                else
                {
                    correctAnswer = mathProblems.secondNumber - mathProblems.firstNumber;
                    temp = mathProblems.firstNumber;
                    mathProblems.firstNumber = mathProblems.secondNumber;
                    mathProblems.secondNumber = temp;
                }
                break;
            case MathOperations.Multiplication:
                mathProblems.firstNumber = Random.Range(0, 20);
                mathProblems.secondNumber = Random.Range(0, 20);
                correctAnswer = mathProblems.firstNumber * mathProblems.secondNumber;
                break;
            case MathOperations.Division:
                mathProblems.firstNumber = Random.Range(1, 100);
                mathProblems.secondNumber = Random.Range(1, 100);
                if (mathProblems.firstNumber >= mathProblems.secondNumber)
                {
                    correctAnswer = mathProblems.firstNumber / mathProblems.secondNumber;
                }
                else
                {
                    correctAnswer = mathProblems.secondNumber / mathProblems.firstNumber;
                    temp = mathProblems.firstNumber;
                    mathProblems.firstNumber = mathProblems.secondNumber;
                    mathProblems.secondNumber = temp;
                }
                break;
        }
        mathProblems.operation = operation;
        mathProblems.answers = new int[4];
        AssignAnswers(mathProblems.answers, correctAnswer);
        ArrayShuffler(mathProblems.answers);
        mathProblems.correctEssence = System.Array.IndexOf(mathProblems.answers, correctAnswer);
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
}
