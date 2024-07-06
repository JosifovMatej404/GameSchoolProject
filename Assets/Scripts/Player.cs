using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float movementSpeed = 3f;
    float jumpSpeed = 70f;
    bool isGrounded = true;
    int jumpCount = 2;

    GameObject hitbox;

    [SerializeField] AudioSource damageClip;
    [SerializeField] AudioClip [] clips;
    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        hitbox = transform.Find("Hitbox").gameObject;
        damageClip = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (getAttacking())
            hitbox.SetActive(true);
        else
            hitbox.SetActive(false);


        if (isGrounded)
            rb.gravityScale = 2.1f;

        transform.position += Vector3.right * movementSpeed * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (!isGrounded)
            {
                rb.gravityScale += 5.1f;
            }
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (jumpCount > 0)
            {
                if (!getAttacking())
                    setJumping(true);
                rb.velocity = new Vector2(rb.velocity.x, 0);
                rb.AddForce(Vector3.up * jumpSpeed);
                isGrounded = false;
                jumpCount--;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space)){
            setAttacking(1);
            SoundFXManager.instance.PlaySoundEffect(damageClip.clip,transform,1f);
        }

        GameObject camera = transform.parent.transform.GetChild(0).gameObject;
        camera.transform.position = new Vector3(transform.position.x + 2, 0.5f, -10f);
    }

    public void setAttacking(float value)
    {
        bool value2 = value > 0;
        GetComponent<Animator>().SetBool("attacking", value2);
    }

    public bool getAttacking()
    {
        return GetComponent<Animator>().GetBool("attacking");
    }

    public void setJumping(bool value)
    {
        GetComponent<Animator>().SetBool("jumping", value);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        isGrounded = true;
        jumpCount = 2;
        setJumping(false);
    }
}
