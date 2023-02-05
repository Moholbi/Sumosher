using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderCrown : MonoBehaviour
{
    [SerializeField] GameObject leaderCrown;
    [SerializeField] GameManager gameManager;
    [SerializeField] Transform[] crownLocations;

    public void TurnOffCrown()
    {
        leaderCrown.SetActive(false);
    }

    public void LocateCrown()
    {
        var parent=GameManager.Leader.CrownHolder;
        transform.SetParent(parent);
        transform.localPosition = Vector3.zero;
        leaderCrown.SetActive(true);
    }
}