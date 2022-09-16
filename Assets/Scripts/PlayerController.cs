using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float gesture = 0;
    

    void Start()
    {
        
    }

    void Update()
    {
        gesture = 0;

        if (Input.GetKeyDown(KeyCode.Q)) {
            gesture = 1;
        }
        if (Input.GetKeyDown(KeyCode.W)) {
            gesture = 2;
        }
        if (Input.GetKeyDown(KeyCode.E)) {
            gesture = 3;
        }
        if (Input.GetKeyDown(KeyCode.R)) {
            gesture = 4;
        }
        



        // if (transform.position.x < -10) {
        //     transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        // }
        // if (transform.position.x > 10) {
        //     transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        // }

        // horizontalInput = Input.GetAxis("Horizontal");
        // transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
    }
}