using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour {

    private float walkSpeed = 5f;
    private float runSpeed = 10f;
    private float zoomSpeed = 25f;
    private float rotationSpeed = 5f;
    private float LookMaxAngle = 45.0f;             //max viewing angle up/down
    private float lookRotationX = 0.0f;             //holds current left/right rotation of camera // Rotade around Y-axis
    private float lookRotationY = 30.0f;            //holds current up/down rotation of camera    // Rotade around X-axis

    float cameraHeight = 10f;

    Rigidbody rigidbody;

    void Start ()
    {
        rigidbody = GetComponent<Rigidbody>();
        transform.localRotation = Quaternion.Euler(lookRotationY, lookRotationX, 0);
    }
	
	void Update ()
    {
        Movement();
        Rotation();
	}

    void Rotation()
    {
        if (Input.GetKey(KeyCode.Mouse1)) // RightMouseButton
        {
            lookRotationX += Input.GetAxis("Mouse X") * rotationSpeed;
            lookRotationY -= Input.GetAxis("Mouse Y") * rotationSpeed;
            lookRotationY = Mathf.Clamp(lookRotationY, -LookMaxAngle, LookMaxAngle);
            transform.localRotation = Quaternion.Euler(lookRotationY, lookRotationX, 0);
            //transform.rotation = Quaternion.Euler(camera.transform.rotation.x, 0, camera.transform.rotation.y);
        }
    }

    void Movement()
    {
        float speed = (Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed);
        
        Vector3 velocity = Vector3.zero; //default = no movement
        Vector3 temp = transform.position;
        
        if (Input.GetKey(KeyCode.W))
        {
            velocity.z += speed * Time.deltaTime * 100;
        }

        if (Input.GetKey(KeyCode.S))
        {
            velocity.z -= speed * Time.deltaTime * 100;
        }

        if (Input.GetKey(KeyCode.A))
        {
            velocity.x -= speed * Time.deltaTime * 100;
        }

        if (Input.GetKey(KeyCode.D))
        {
            velocity.x += speed * Time.deltaTime * 100;
        }
        
        if (Input.GetAxis("Mouse ScrollWheel") > 0f) // forward
        {
            cameraHeight -= zoomSpeed * Time.deltaTime;
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0f) // backwards
        {
            cameraHeight += zoomSpeed * Time.deltaTime;
        }
        rigidbody.velocity = Vector3.Lerp(transform.TransformVector(velocity), Vector3.zero, 0.2f); //overwrite existing velocity with our own
        
        // lock Y-axis to cameraHeight
        temp.x = transform.position.x;
        temp.y = cameraHeight;
        temp.z = transform.position.z;
        transform.position = temp;
    }
}
