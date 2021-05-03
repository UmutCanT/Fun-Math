using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EcController : MonoBehaviour
{

    // instance
    public static EcController instance;

    void Awake()
    {
        instance = this;
    }

    public MathProblems[] mProblems;      // list of all problems
    //current problem the player needs to solve
    public int curProblem;

    [SerializeField]
    GameObject playerPrefab = default; // player object

    // Start is called before the first frame update
    void Start()
    {
        SetProblems(0);
    }

    // Update is called once per frame
    void Update()
    {
        
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
            Destroy(GameObject.FindGameObjectWithTag("Player"));
        else
            SetProblems(curProblem + 1);
    }

    void CorrectEssence()
    {
        Debug.Log("Correct");

        if (mProblems.Length - 1 == curProblem)
            Destroy(GameObject.FindGameObjectWithTag("Player"));
        else
            SetProblems(curProblem + 1);
    }

    // called when the player enters a tube
    public void OnCollectingEssence(int essence)
    {
        // did they enter the correct tube?
        if (essence == mProblems[curProblem].correctEssence)
        {
            CorrectEssence();
        }
        else
        {
            WrongEssence();
        }
    }
}
