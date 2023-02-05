using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HittingOpponent : MonoBehaviour
{
    [SerializeField] EatingFood eatingFood;
    Transform target;
    int hitPower;

    [SerializeField] int hitMultiplier;
    [SerializeField] int critMultiplier;

    void OnCollisionEnter(Collision other)
    {
        hitPower = eatingFood.powerLevel * hitMultiplier;
        target = other.transform;
        Vector3 targetDir = target.position - transform.position;
        float angle = Vector3.Angle(targetDir, transform.forward);

        if (other.gameObject.layer == LayerMask.NameToLayer("Sumo"))
        {
            other.rigidbody.AddForce(targetDir * hitPower);
            Debug.Log("hit");
        }

        if (other.gameObject.layer == LayerMask.NameToLayer("HitMark"))
        {
            other.rigidbody.AddForce(targetDir * critMultiplier);
            Debug.Log("crit");
        }
    }
}