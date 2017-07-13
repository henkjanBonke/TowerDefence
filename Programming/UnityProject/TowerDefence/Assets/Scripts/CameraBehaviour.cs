using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour {

    private float walkSpeed = 20f;
    private float runSpeed = 400f;

    Rigidbody rigidbody;                //reference to rigidbody (used to apply forces)

    void Start ()
    {
        rigidbody = GetComponent<Rigidbody>();
    }
	
	void Update ()
    {
        Movement();
        Rotation();
	}

    void Rotation()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(0, -1, 0, Space.World);
        }
        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(0, 1, 0, Space.World);
        }
    }

    void Movement()
    {
        Vector3 velocity = Vector3.zero; //default = no movement
        float speed = (Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed);

        if (Input.GetKey(KeyCode.W))
        {
            velocity.z += speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            velocity.z -= speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            velocity.x -= speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            velocity.x += speed * Time.deltaTime;
        }

        //velocity.y = rigidbody.velocity.y; //keep gravity (on y-axis)
        rigidbody.velocity = transform.TransformVector(velocity); //overwrite existing velocity with our own
    }
}
