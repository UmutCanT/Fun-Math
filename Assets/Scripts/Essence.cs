using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Essence : MonoBehaviour
{
    CircleCollider2D circleCollider2D;
    Rigidbody2D rbd2;

    int essenceID;

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

    public int SettingID
    {
        set
        {
            essenceID = value;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        circleCollider2D = GetComponent<CircleCollider2D>();
        rbd2 = GetComponent<Rigidbody2D>();
        randomFallingSpeed = Random.Range(5.0f, 10.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (isFalling)
        {
            rbd2.drag = randomFallingSpeed;
            Debug.Log(essenceID);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {       
        if (col.CompareTag("Player"))
        {
            EcController.instance.OnCollectingEssence(essenceID);
            OnPlayerCollision();          
        }
        if (col.CompareTag("Ground"))
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
