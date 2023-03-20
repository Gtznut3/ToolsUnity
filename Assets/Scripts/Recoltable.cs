using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recoltable : MonoBehaviour
{
    private GameObject Player;
    [SerializeField] private float detectionRadius;
    [SerializeField] private RecoltableManager manager;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }


    public void Update()
    {
        if(Player && Vector3.Distance(Player.transform.position, transform.position)<= detectionRadius)
        {
            manager.RemoveRecoltable(this);
            Destroy(gameObject);
        }
    }
}
