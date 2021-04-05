using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EcController : MonoBehaviour
{

    // instance
    public static EcController instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

    }

    public MathProblems[] mProblems;      // list of all problems
    //current problem the player needs to solve
    public int curProblem;          

    public PlayerMoves player; // player object

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetProblems(int problem)
    {
        curProblem = problem;
        // set UI text to show problem and answers
    }

    void GameOver()
    {
        //If the player healt is 0 game over.
    }

    void WrongEssence()
    {
        //Player lose health.
    }

    void CorrectEssence()
    {
       //Score ++
       //new set of problems
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
