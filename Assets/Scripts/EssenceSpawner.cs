using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EssenceSpawner : MonoBehaviour
{
   

    Countdown countdown;

    

    // Start is called before the first frame update
    void Start()
    {
        countdown = gameObject.AddComponent<Countdown>();
        countdown.TotalTime = 8;
        countdown.RunCountdown();
    }

    // Update is called once per frame
    void Update()
    {
        
    }    
}
