using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMoves : MonoBehaviour
{
    Rigidbody2D rb2d;
    Animator animator;

    Vector2 velocity;

    //Player Attributes
    [SerializeField]
    float runSpeed = default;
    [SerializeField]
    float acceleration = default;
    [SerializeField]
    float deceleration = default;

    bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_EDITOR
        KeyboardConroller();
#else
        TouchScreenController();
#endif
    }

    // Controller for testing in Unity
    void KeyboardConroller()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");
        Moving(moveInput);
    }

    //Controller for Android Device
    void TouchScreenController()
    {
        float moveInput = TouchingMovement();
        Moving(moveInput);
    }

    void Moving(float move)
    {
        Vector2 scale = transform.localScale;

        if (move > 0)
        {
            //(current value, target value, delta)
            velocity.x = Mathf.MoveTowards(velocity.x, move * runSpeed, acceleration * Time.deltaTime);
            animator.SetBool("Running", true);
            scale.x = 0.7f;
        }
        else if (move < 0)
        {
            velocity.x = Mathf.MoveTowards(velocity.x, move * runSpeed, acceleration * Time.deltaTime);
            animator.SetBool("Running", true);
            scale.x = -0.7f;
        }
        else
        {
            velocity.x = Mathf.MoveTowards(velocity.x, 0, deceleration * Time.deltaTime);
            animator.SetBool("Running", false);
        }
        transform.localScale = scale;
        transform.Translate(velocity * Time.deltaTime);
    }

    //Getting the touch input
    float TouchingMovement()
    {
        Touch theTouch;
        if (Input.touchCount > 0)
        {
            theTouch = Input.GetTouch(0);
            if (theTouch.position.x < Screen.width/2)
            {
                return -1f;
            }
            else if (theTouch.position.x > Screen.width/2)
            {
                return 1f;
            }
            else
                return 0f;
        }
        else
        {
            return 0f;
        }
    }

    /// <summary>
    /// Animation for wrong essence pickup
    /// </summary>
    public void DamagedAnimation()
    {
        animator.SetTrigger("Hit");       
    }
}
