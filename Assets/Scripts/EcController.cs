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

    public MathProblems[] mProblems;      // list of all problems
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
        SetProblems(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (countdown.Finished)
        {
            SpawnEssence();
            countdown.RunCountdown();
        }
    }

    void SetProblems(int problem)
    {
        curProblem = problem;
        EcUI.instance.SetProblemText(mProblems[curProblem]);
    }

    void GameOver()
    {
        //If the player healt is 0 game over.
    }

    void WrongEssence()
    {
        Debug.Log("Wrong");

        if (mProblems.Length - 1 == curProblem)
            Destroy(GameObject.FindGameObjectWithTag("Essence"));
        else
            SetProblems(curProblem + 1);
    }

    void CorrectEssence()
    {
        Debug.Log("Correct");

        if (mProblems.Length - 1 == curProblem)
            Destroy(GameObject.FindGameObjectWithTag("Essence"));
        else
            SetProblems(curProblem + 1);
    }

    // called when the player enters a tube
    public void OnCollectingEssence(int essenceID)
    {
        // did they enter the correct tube?
        if (essenceID == mProblems[curProblem].correctEssence)
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
            Debug.Log(i + ". essence fabricated");
            essence.GetComponentInChildren<Text>().text = EcUI.instance.SetAnswerText(mProblems[curProblem], i);
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
}
