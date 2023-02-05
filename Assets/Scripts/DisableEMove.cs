using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableEMove : MonoBehaviour
{
    [SerializeField] EnemyMovement enemyMovement;
    float timer;

    void Update()
    {
        Enable();
    }

    void Disable()
    {
        timer = 0.5f;

        if (timer >= 0)
        {
            enemyMovement.enabled = false;
        }
    }

    void Enable()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            enemyMovement.enabled = true;
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Sumo"))
        {
            Disable();
        }
    }
}