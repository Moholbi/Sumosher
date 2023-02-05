using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float turnSpeed;
    [SerializeField] float inputThreshold;
    [SerializeField] FloatingJoystick floatingJoystick;
    [SerializeField] Animator runAnim;
    [SerializeField] Rigidbody rb;
    [SerializeField] GameManager gameManager;
    [SerializeField] WinScreen winScreen;

    public bool isRunning;
    float pepperTimer;

    void Update()
    {
        if (!isRunning) return;

        PepperDecrease();
        JoystickMovement();
        runAnim.SetBool("isRunning", true);
    }

    void JoystickMovement()
    {
        var joyDir = floatingJoystick.Direction;
        if (joyDir.sqrMagnitude > inputThreshold)
        {
            isRunning = true;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(new Vector3(joyDir.x, 0, joyDir.y)), turnSpeed * Time.deltaTime);
        }

        transform.position += transform.forward * moveSpeed * Time.deltaTime;
    }

    void OnTriggerEnter(Collider other)
    {
        if (!isRunning) return;

        if (other.gameObject.tag == "Pepper")
        {
            HasPepper();
        }
        if (other.CompareTag("Cleaner"))
        {
            isRunning = false;
            gameManager.GameOver();
        }
    }

    void HasPepper()
    {
        pepperTimer = 5f;
    }

    void PepperDecrease()
    {
        if (pepperTimer > 0)
        {
            pepperTimer -= Time.deltaTime;
            moveSpeed = 10f;

            if (pepperTimer <= 0)
            {
                moveSpeed = 5f;
            }
        }
    }
    public void StartStopRun(bool playing)
    {
        isRunning = playing;
    }
}