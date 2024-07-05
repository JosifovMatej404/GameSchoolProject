using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEye : BaseEnemy
{
    float randomHeight = 1;

    void Start()
    {
        randomHeight = Random.Range(0f, 2.2f);
        transform.position = new Vector3(transform.position.x, randomHeight, transform.position.z);       
    }
}
