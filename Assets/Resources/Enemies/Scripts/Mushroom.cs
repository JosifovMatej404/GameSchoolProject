using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : BaseEnemy
{
    // Start is called before the first frame update
    int jumpCount = 1;
    float jumpSpeed = 70f;
    bool isGrounded = false;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isGrounded && Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (jumpCount > 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, 0);
                rb.AddForce(Vector3.up * jumpSpeed);
                jumpCount--;
                isGrounded = false;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name.Contains("Player"))
        {
            KillEnemy();
        }
        else
        {
            isGrounded = true;
            jumpCount = 1;

        }
    }
}
