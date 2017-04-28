using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class King : MonoBehaviour {

    public float startHealth = 100;
    public float startPower = 50;
    public static float power;
    public static float health;

    private bool isDead = false;

    // Use this for initialization
    void Start () {
        health = startHealth;
        power = startPower;
    }


    public void TakeDamage(float amount)
    {
        if (Mecanim_Control_melee.defense)
        {
            health -= amount/2;
        }
        else
        {
            health -= amount;
        }
        

        if (health <= 0 && !isDead)
        {
            Die();
        }
    }

    public void Die()
    {
        isDead = true;
        PlayerStats.Lives = 0;
        Destroy(gameObject);
    }
    
}
