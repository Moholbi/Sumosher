using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class CollectableBehaviour : MonoBehaviour
{
    [SerializeField] float turnSpeed;
    [SerializeField] BoxCollider capsuleCollider;
    bool eaten = false;

    void Start()
    {
        capsuleCollider = GetComponent<BoxCollider>();
    }

    void Update()
    {
        transform.Rotate(0, turnSpeed * Time.deltaTime, 0);
    }

    void OnTriggerEnter(Collider other)
    {
        if (eaten) return;

        var mouth = other.gameObject.transform.GetChild(0);
        eaten = true;
        capsuleCollider.enabled = false;

        transform.DOJump(mouth.position, 0.1f, 1, 0.2f);
        transform.DOScale(0, 0.2f)
            .OnComplete(() => Destroy(gameObject));


        SushiSpawner.CollectableList.Remove(transform);
    }
}
