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
        //Essence drop speed according to the chosen difficulty
        if(PrefSystem.GetEasyDiff() == 1)
        {
            randomFallingSpeed = 20f;
        }
        if (PrefSystem.GetMediumDiff() == 1)
        {
            randomFallingSpeed = 15f;
        }
        if (PrefSystem.GetHardDiff() == 1)
        {
            randomFallingSpeed = 10f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isFalling)
        {
            rbd2.drag = randomFallingSpeed;          
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
    }
    
    void OnGroundCollision()
    {
        Destroy(gameObject);
    }
}
