using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Essence : MonoBehaviour
{
    CapsuleCollider2D capsuleCollider2D;
    Rigidbody2D rbd2;
    Text problemText;

    float randomFallingSpeed;
    bool isFalling;

    public bool Falling
    {
        get
        {
            return isFalling;
        }
        set
        {
            isFalling = value;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        capsuleCollider2D = GetComponent<CapsuleCollider2D>();
        rbd2 = GetComponent<Rigidbody2D>();
        problemText = GetComponent<Text>();

        randomFallingSpeed = Random.Range(5.0f, 10.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (isFalling)
        {
            rbd2.drag = randomFallingSpeed;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {       
        if (collision.gameObject.tag == "Player")
        {
            OnPlayerCollision();
        }
        if (collision.gameObject.tag == "Ground")
        {
            OnGroundCollision();
        }
    }
    void OnPlayerCollision()
    {
        Destroy(gameObject);
        Debug.Log("Player Collected");
    }
    
    void OnGroundCollision()
    {
        Destroy(gameObject);
        Debug.Log("Destroyed");
    }
}
