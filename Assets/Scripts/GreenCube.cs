using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GreenCube : MonoBehaviour
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
        
        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            moveZ = 1;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow)) {
            moveZ = -1;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            moveX = -1;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow)) {
            moveX = 1;
        }

        Vector3 movement = new Vector3(moveX, 0f, moveZ). normalized;
        transform.Translate(movement * moveSpeed * Time.deltaTime);
    }

    void FixedUpdate() {
        //rb.velocity = new Vector3(moveX * moveSpeed * Time.deltaTime, rb.velocity.y, moveZ * moveSpeed * Time.deltaTime);

    }
}
