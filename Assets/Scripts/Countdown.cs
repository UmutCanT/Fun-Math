using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Countdown : MonoBehaviour
{
    float totalTime = 0;
    float passingTime = 0;

    bool isRunning;
    bool isStarted;

    /// <summary>
    /// Countdown's total time can be set from here
    /// </summary>
    public float TotalTime
    {
        set
        {
            //if any countdown isn't running we can set the total time
            if (!isRunning)
            {
                totalTime = value;
            }
        }
    }

    /// <summary>
    /// Checks whether countdown is finished or not
    /// </summary>
    public bool Finished
    {
        get
        {
            return isStarted && !isRunning;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isRunning)
        {
            passingTime += Time.deltaTime;
            if(passingTime >= totalTime)
            {
                isRunning = false;
            }
        }
    }

    /// <summary>
    /// Runs the countdown
    /// </summary>
    public void RunCountdown()
    {
        if(totalTime > 0)
        {
            isRunning = true;
            isStarted = true;
            passingTime = 0;
        }
    }
}
