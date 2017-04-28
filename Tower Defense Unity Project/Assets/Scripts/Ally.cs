using UnityEngine;
using UnityEngine.UI;

public class Ally : MonoBehaviour
{

    public float startSpeed = 10f;
    
    [HideInInspector]
    public float speed;

    public bool walking = false;
    public bool attacking = false;
    public bool trancing = false;

    public Animator anim;

    public float startHealth = 100;
    private float health;

    public GameObject deathEffect;

    [Header("Unity Stuff")]
    public Image healthBar;

    private bool isDead = false;



    void Start()
    {
        speed = startSpeed;
        health = startHealth;

        anim = GetComponent<Animator>();
    }

    public void TakeDamage(float amount)
    {
        health -= amount;

        //healthBar.fillAmount = health / startHealth;

        if (health <= 0 && !isDead)
        {
            Die();
        }
    }

    public void Slow(float pct)
    {
        speed = startSpeed * (1f - pct);
    }

    void Die()
    {
        isDead = true;

        GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);

        Destroy(gameObject);
    }

}
