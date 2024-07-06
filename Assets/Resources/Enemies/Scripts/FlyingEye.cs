using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEye : BaseEnemy
{
    float randomHeight = 1;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        health = maxHealth;
        randomHeight = Random.Range(0f, 1.5f);
        rb.gravityScale = 0;
        transform.position = new Vector3(transform.position.x, randomHeight, transform.position.z);       
    }
    public new void KillEnemy()
    {
        rb.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<Animator>().SetBool("dead", true);
    }
}
