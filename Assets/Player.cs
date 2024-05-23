using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float movementSpeed = 3f;
    float jumpSpeed = 70f;
    bool isGrounded = true;
    int jumpCount = 2;

    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        if (isGrounded)
        {
            rb.gravityScale = 2.1f;
        }
        
        transform.position += Vector3.right * movementSpeed * Time.deltaTime;

        if (Input.GetKey(KeyCode.DownArrow))
        {
            if (!isGrounded)
            {
                rb.gravityScale += 2;
            }
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (jumpCount > 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, 0);
                rb.AddForce(Vector3.up * jumpSpeed);
                isGrounded = false;
                jumpCount--;
            }
        }

        //gets floor by accesssing parent and getting last childs gameobject
        GameObject floor = transform.parent.GetChild(transform.parent.GetComponent<Transform>().childCount - 1).gameObject;
        floor.GetComponent<Transform>().position = new Vector2(transform.position.x, -1f);
        GameObject camera = transform.parent.transform.GetChild(0).gameObject;
        camera.transform.position = new Vector3(transform.position.x, 0.5f, -10f);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        isGrounded = true;
        jumpCount = 2;
    }
}
