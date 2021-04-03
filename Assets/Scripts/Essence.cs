using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Essence : MonoBehaviour
{
    CapsuleCollider2D capsuleCollider2D;
    Rigidbody2D rbd2;

    float randomFallingSpeed;
    bool isFalling = true;

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

        randomFallingSpeed = Random.Range(1.0f, 20.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (isFalling)
        {
            rbd2.drag = randomFallingSpeed;
        }
    }
}
