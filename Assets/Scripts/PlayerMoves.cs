using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMoves : MonoBehaviour
{
    Rigidbody2D rb2d;
    Animator animator;

    Vector2 velocity;
    //Problem text for player
    Text problemText;

    public string Problem
    {
        set
        {
            problemText.text = value;
        }
    }

    //Player Attributes
    [SerializeField]
    float runSpeed = default;
    [SerializeField]
    float acceleration = default;
    [SerializeField]
    float deceleration = default;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        problemText = GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        KeyboardConroller();
    }

    /// <summary>
    /// Controller for testing in Unity
    /// </summary>
    void KeyboardConroller()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");
        Vector2 scale = transform.localScale;

        if(moveInput > 0)
        {
            //(current value, target value, delta)
            velocity.x = Mathf.MoveTowards(velocity.x, moveInput * runSpeed, acceleration * Time.deltaTime);
            animator.SetBool("Run", true);
            scale.x = 0.3f;
        }else if(moveInput < 0)
        {
            velocity.x = Mathf.MoveTowards(velocity.x, moveInput * runSpeed, acceleration * Time.deltaTime);
            animator.SetBool("Run", true);
            scale.x = -0.3f;
        }
        else
        {
            velocity.x = Mathf.MoveTowards(velocity.x, 0, deceleration * Time.deltaTime);
            animator.SetBool("Run", false);
        }
        transform.localScale = scale;
        transform.Translate(velocity * Time.deltaTime);
    }
}
