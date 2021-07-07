using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimSystem : MonoBehaviour
{
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_EDITOR
        MouseController();
#else
        TouchScreenController();
#endif
    }

    void Aim(Vector3 controllerPosition)
    {
        if (controllerPosition.y > -ScreenSizeManager.instance.Height / 3)
        {
            if (controllerPosition.x < -ScreenSizeManager.instance.Witdh / 2)
            {
                animator.SetInteger("LookingWay", 2);
            }
            else if (-ScreenSizeManager.instance.Witdh / 2 <= controllerPosition.x && controllerPosition.x <= ScreenSizeManager.instance.Witdh / 2)
            {
                animator.SetInteger("LookingWay", 0);
            }
            else if (controllerPosition.x > ScreenSizeManager.instance.Witdh / 2)
            {
                animator.SetInteger("LookingWay", 1);
            }
        }
    }


    //Controller for testing in Unity
    void MouseController()
    {
        Vector3 mousePosition = new Vector3(0, 0, 0);

        if (Input.GetMouseButtonDown(0))
        {
            mousePosition = GetMouseWorldPosition();
            Aim(mousePosition);
        }
    }

    //Controller for Android device
    void TouchScreenController()
    {        
        Touch theTouch;
        if (Input.touchCount > 0)
        {
            theTouch = Input.GetTouch(0);
            Vector3 touchPosition = GetWorldPositionWithZ(theTouch.position, Camera.main);
            touchPosition.z = 0f;
            Aim(touchPosition);
        }
    }

    Vector3 GetMouseWorldPosition()
    {
        Vector3 vec = GetWorldPositionWithZ(Input.mousePosition, Camera.main);
        vec.z = 0f;
        return vec;
    }

    Vector3 GetWorldPositionWithZ(Vector3 screenPosition, Camera worldCamera)
    {
        Vector3 worldPosition = worldCamera.ScreenToWorldPoint(screenPosition);
        return worldPosition;
    }  
}
