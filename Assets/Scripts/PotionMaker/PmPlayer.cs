using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PmPlayer : MonoBehaviour
{
    int health;
    int healthMax;

    public int GetHealth
    {
        get
        {
            return health;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        HealthAssigner(40);
    }

    void HealthAssigner(int healthMax)
    {
        this.healthMax = healthMax;
        health = healthMax;
    }

    public void Damage(int damageAmount)
    {
        health -= damageAmount;
        if (health < 0)
        {
            health = 0;
        }
        Dying(health);
    }

    void Dying(int health)
    {
        if (health <= 0)
        {
            FindObjectOfType<PmController>().GameOver(false);
            gameObject.GetComponent<PmPlayerController>().enabled = false;          
        }
    }
}
