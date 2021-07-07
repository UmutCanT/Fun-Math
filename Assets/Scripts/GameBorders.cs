using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBorders : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //for left side of screen
        if (transform.position.x < -ScreenSizeManager.instance.Witdh)
        {
            Vector2 temp = transform.position;
            temp.x = -ScreenSizeManager.instance.Witdh;
            transform.position = temp;
        }
        //for right side of screen
        if (transform.position.x > ScreenSizeManager.instance.Witdh)
        {
            Vector2 temp = transform.position;
            temp.x = ScreenSizeManager.instance.Witdh;
            transform.position = temp;
        }    
    }
}
