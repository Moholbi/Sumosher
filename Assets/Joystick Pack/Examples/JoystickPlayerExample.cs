using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickPlayerExample : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float turnSpeed;
    [SerializeField] FloatingJoystick floatingJoystick;

    Rigidbody rb;

    Vector3 addedPos;
    Vector3 direction;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            JoystickMovement();
        }
    }

    void JoystickMovement()
    {
        float horizontal = floatingJoystick.Horizontal;
        float vertical = floatingJoystick.Vertical;

        addedPos = new Vector3(horizontal * moveSpeed * Time.deltaTime, 0, vertical * moveSpeed * Time.deltaTime);
        rb.velocity += addedPos;

        if (floatingJoystick.Horizontal != 0 || floatingJoystick.Vertical != 0)
        {
            direction = Vector3.forward * vertical + Vector3.right * horizontal;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), turnSpeed * Time.deltaTime);
        }
    }
}