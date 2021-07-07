using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fullscreen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //We use the sprite renderer component, to rearrange the size of the background image to the resolution 
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        Vector2 tempScale = transform.localScale;

        float bgWidth = spriteRenderer.size.x;

        float screenHeight = Camera.main.orthographicSize * 2;
        //Screen class is for taking device screen resolution values 
        float screenWidth = screenHeight / Screen.height * Screen.width;

        tempScale.x = screenWidth / bgWidth;
        transform.localScale = tempScale;
    }
}
