using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedCube : MonoBehaviour
{
    public float moveSpeed = 5f;
    float moveX;
    float moveZ;

    Rigidbody rb;

    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        moveX = 0;
        moveZ = 0;

    }

    
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.W)) {
            moveZ = 1;
        }
        if (Input.GetKeyDown(KeyCode.S)) {
            moveZ = -1;
        }
        if (Input.GetKeyDown(KeyCode.A)) {
            moveX = -1;
        }
        if (Input.GetKeyDown(KeyCode.D)) {
            moveX = 1;
        }

        Vector3 movement = new Vector3(moveX, 0f, moveZ). normalized;
        transform.Translate(movement * moveSpeed * Time.deltaTime);
    }
}
