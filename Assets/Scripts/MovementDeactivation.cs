using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementDeactivation : MonoBehaviour
{
    [SerializeField] PlayerMovement playerMovement;
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
            playerMovement.enabled = false;
        }
    }

    void Enable()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            playerMovement.enabled = true;
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