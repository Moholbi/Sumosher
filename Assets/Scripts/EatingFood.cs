using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatingFood : MonoBehaviour
{
    public int sushiScore {get; private set;}
    public int powerLevel {get; private set;}

    [field: SerializeField] public Transform CrownHolder {get; private set;}

    [SerializeField] GameManager gameManager;

    void Start()
    {
        powerLevel = 100;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == ("Sushi"))
        {
            sushiScore += 100;
            powerLevel += 10;
            transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);
            gameManager.DecideLeader();
        }
    }
}