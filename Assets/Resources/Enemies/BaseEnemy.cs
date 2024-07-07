using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    protected int health = 0;
    protected int maxHealth = 2;
    protected Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        health = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0) KillEnemy();
    }
    public void KillEnemy()
    {
        rb.gravityScale = 0f;
        rb.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<Animator>().SetBool("dead", true);
        PlayerPrefs.SetInt("Score",PlayerPrefs.GetInt("Score")+5);
        PlayerPrefs.Save();
    }

    public void DestroyEnemy()
    {
        Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Contains("Player"))
        {
            transform.parent.GetComponent<HealthManager>().PlayerTakeDamage();
            rb.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            rb.gravityScale = 0f;
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Contains("fireball"))
        {
            KillEnemy();
        }
        if (collision.gameObject.name.Contains("Hitbox") && collision.transform.parent.GetComponent<Player>().getAttacking())
        {
            KillEnemy();
        }
    }
}