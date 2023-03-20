using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WinDetection : MonoBehaviour
{
    private GameObject Player;
    [SerializeField] private float detectionRadius;
    [SerializeField] private GameObject WinScreen;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }


    public void Update()
    {
        if (Player && Vector3.Distance(Player.transform.position, transform.position) <= detectionRadius)
        {
            WinScreen.SetActive(true);
            Player.GetComponent<NavMeshAgent>().isStopped = true;
        }
    }
}
