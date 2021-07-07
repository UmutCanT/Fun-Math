using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Monster : MonoBehaviour
{
    int monsterPosition;

    Countdown countdown;


    /// <summary>
    /// Monster position to match player position
    /// </summary>
    public int MonsterPosition
    {
        set
        {
            monsterPosition = value;
        }
        get
        {
            return monsterPosition;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        countdown = gameObject.AddComponent<Countdown>();
        countdown.TotalTime = SetInterval();
        countdown.RunCountdown();
    }

    // Update is called once per frame
    void Update()
    {
        if (countdown.Finished)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<HPlayer>().Damage(10);
            countdown.RunCountdown();
        }
    }

    float SetInterval()
    {
        if (HPrefSystem.GetEasyHDiff() == 1)
        {
            return 10f;
        }
        if (HPrefSystem.GetMediumHDiff() == 1)
        {
            return 7f;
        }
        if (HPrefSystem.GetHardHDiff() == 1)
        {
            return 5f;
        }

        return 7f;
    }
}
