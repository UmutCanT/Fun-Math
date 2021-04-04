using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenSizeManager : MonoBehaviour
{
    //Singleton instance for all scenes
    public static ScreenSizeManager instance;

    float height;
    float witdh;

    //Properties for accessing to height from outside
    public float Height
    {
        get
        {
            return height;
        }
    }
    public float Witdh
    {
        get
        {
            return witdh;
        }
    }

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }else if(instance != this)
        {
            Destroy(gameObject);
        }

        height = Camera.main.orthographicSize;
        witdh = height * Camera.main.aspect;
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
