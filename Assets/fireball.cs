using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireball : MonoBehaviour
{
    float  movementSpeed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnBecameInvisible() {
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
         transform.position += Vector3.right * movementSpeed * Time.deltaTime;   
    }
}
