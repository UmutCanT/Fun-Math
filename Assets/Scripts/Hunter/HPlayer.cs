using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPlayer : MonoBehaviour
{
    MeterScript healthMeter;

    Animator animator;

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
        healthMeter = GameObject.FindGameObjectWithTag("PlayerHealth").GetComponent<MeterScript>();
        animator = GetComponent<Animator>();
        HealthAssigner(40);
    }

    // Update is called once per frame
    void Update()
    {
        healthMeter.SetHealth(health);
    }

    void HealthAssigner(int healthMax)
    {
        this.healthMax = healthMax;
        health = healthMax;
        healthMeter.SetMaxHealth(healthMax);
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
            animator.SetTrigger("Death");
            gameObject.GetComponent<AimSystem>().enabled = false;
            FindObjectOfType<HController>().GameOver(false);
        }
    }
}
