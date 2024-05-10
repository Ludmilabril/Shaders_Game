using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement: MonoBehaviour
{
    public float speed = 5;
    public static bool lastKeyUp;

    private Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        move();
    }
    private void move()
    {
        float inputX = Input.GetAxis("Horizontal");

        Vector3 movement = new Vector3( 0.0f, 0.0f, inputX);

       
        if (Input.GetKey(KeyCode.D)) 
        {
            transform.rotation = Quaternion.Euler(0, 90, 0);
            movement = new Vector3(0.0f, 0.0f, inputX * 1.0f);
            transform.Translate(movement * Time.deltaTime * speed);
        }
        else if (Input.GetKey(KeyCode.A)) 
        {
            transform.rotation = Quaternion.Euler(0, -90, 0);
            movement = new Vector3(0.0f, 0.0f, inputX * -1.0f);
            transform.Translate(movement * Time.deltaTime * speed);
        }

    }
}
