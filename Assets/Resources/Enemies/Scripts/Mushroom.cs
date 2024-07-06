using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : BaseEnemy
{
    // Start is called before the first frame update
    int jumpCount = 1;
    float jumpSpeed = 70f;
    bool isGrounded = false;

    // Update is called once per frame
    void Update()
    {
        if (isGrounded && Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (jumpCount > 0 && !GetComponent<Animator>().GetBool("dead"))
            {
                rb.velocity = new Vector2(rb.velocity.x, 0);
                rb.AddForce(Vector3.up * jumpSpeed);
                jumpCount--;
                isGrounded = false;
            }
        }
    }
    public new void KillEnemy()
    {
        rb.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<Animator>().SetBool("dead", true);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Contains("Player"))
        {
            transform.parent.GetComponent<HealthManager>().PlayerTakeDamage();
            rb.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            rb.gravityScale = 0f;
        }
        else
        {
            isGrounded = true;
            rb.gravityScale = 2.1f;
            jumpCount = 1;
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        print(collision.gameObject.name);

        if (collision.gameObject.name.Contains("fireball"))
        {
            KillEnemy();
        }
        if (collision.gameObject.name.Contains("Hitbox"))
        {
            KillEnemy();
        }
    }
}
