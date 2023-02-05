using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float turnSpeed;
    [SerializeField] Animator runAnim;
    [SerializeField] GameManager gameManager;

    Quaternion rotGoal;
    Transform target;
    Vector3 targetPos;

    Rigidbody rb;
    int targetIndex;
    float timer;
    float pepperTimer;
    bool isRunning;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        timer = 3f;
    }

    void Update()
    {
        if (!isRunning) return;

        Movement();
        PepperDecrease();
        runAnim.SetBool("isRunning", isRunning);
    }

    void Movement()
    {
        timer -= Time.deltaTime;

        if (timer <= 0 || target == null)
        {
            timer = 3f;
            DecideTarget();
        }

        transform.LookAt(target.position);
        transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (!isRunning) return;

        if (other.CompareTag("Pepper"))
        {
            HasPepper();
        }

        if (other.CompareTag("Cleaner"))
        {
            gameManager.EaterDied(transform);
            isRunning = false;
            Destroy(gameObject, 1f);
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

    private void DecideTarget()
    {
        target = null;
        while (target == null || target == transform)
        {
            target = GameManager.EatersList[Random.Range(0, GameManager.EatersList.Count)];
        }
    }
}