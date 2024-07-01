using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWizard : MonoBehaviour
{

    float movementSpeed = 3f;
    Rigidbody2D rb;
    [SerializeField] GameObject fireball;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();
        CameraFollow();
        if(Input.GetKeyDown(KeyCode.Space))
        {
            setAttacking(1);
        }
    }
    
    private void Move()
    {
        float moveInputY = 0f;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            moveInputY = 1f;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            moveInputY = -1f;
        }
        Vector2 velocity = new Vector2(0, moveInputY * movementSpeed * Time.deltaTime);
        rb.velocity = velocity;
        transform.position += Vector3.right * movementSpeed * Time.deltaTime;
        
        Vector3 newPosition = new Vector3();

         if (IsGrounded() && Input.GetKey(KeyCode.DownArrow)){
           return;
         }
         newPosition = transform.position + Vector3.up * moveInputY * movementSpeed * Time.deltaTime;
        float halfHeight = Camera.main.orthographicSize;
        newPosition.y = Mathf.Clamp(newPosition.y, -halfHeight, halfHeight);
         transform.position = newPosition;
    }


    public void CameraFollow(){
        GameObject camera = transform.parent.transform.GetChild(0).gameObject;
        camera.transform.position = new Vector3(transform.position.x + 2, 0.5f, -10f);
    }

    public void setAttacking(float value)
    {
        bool value2 = value > 0;
        GetComponent<Animator>().SetBool("attacking", value2);
    }

    bool IsGrounded()
    {
        int layerMask = LayerMask.GetMask("Terrain");
        return Physics2D.Raycast(transform.position, -Vector3.up, 0.4f, layerMask);
    }

    public bool getAttacking()
    {
        return GetComponent<Animator>().GetBool("attacking");
    }
    public void Attack(){

        GameObject instance = Instantiate(fireball,transform.parent.transform);
        instance.transform.position = transform.GetChild(1).transform.position;
        GetComponent<Animator>().SetBool("attacking", false);

    }

}
