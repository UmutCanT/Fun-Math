using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EssenceSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject essencePrefab;

    Countdown countdown;

    // Start is called before the first frame update
    void Start()
    {
        countdown = gameObject.AddComponent<Countdown>();
        countdown.TotalTime = 3;
        countdown.RunCountdown();
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

    void SpawnEssence()
    {
        Instantiate(essencePrefab);
    }
}
