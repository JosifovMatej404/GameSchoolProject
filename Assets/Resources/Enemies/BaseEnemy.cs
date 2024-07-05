using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    private int health = 0;
    private int maxHealth = 2;

    void Start()
    {
        health = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0) KillEnemy();
    }
    public void KillEnemy()
    {
        GetComponent<Animator>().SetBool("dead", true);
    }

    public void DestroyEnemy()
    {
        Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Contains("Player"))
        {
            KillEnemy();
        }
    }
}