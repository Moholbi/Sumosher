using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SushiSpawner : MonoBehaviour
{
    public static List<Transform> CollectableList;
    
    [SerializeField] GameObject sushiPrefab;
    [SerializeField] GameObject pepperPrefab;

    [SerializeField] float sushiTimer = 2f;
    [SerializeField] float pepperTimer = 8f;

void Awake()
{
    CollectableList = new List<Transform>();
}
    void Update()
    {
        SushiSpawn();
        PepperSpawn();
    }

    void SushiSpawn()
    {
        sushiTimer -= Time.deltaTime;

        if (sushiTimer <= 0)
        {
            float x = Random.Range(-10, 10);
            float z = Random.Range(-10, 10);

            sushiTimer = 2f;
            var s=Instantiate(sushiPrefab, new Vector3(x, 0.5f, z), Quaternion.identity);
            CollectableList.Add(s.transform);
        }
    }

    void PepperSpawn()
    {
        pepperTimer -= Time.deltaTime;

        if (pepperTimer <= 0)
        {
            float x = Random.Range(-10, 10);
            float z = Random.Range(-10, 10);

            pepperTimer = 8f;
            var p = Instantiate(pepperPrefab, new Vector3(x, 1, z), Quaternion.identity);
            CollectableList.Add(p.transform);
        }
    }
}