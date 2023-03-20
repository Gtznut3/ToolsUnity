using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private EnemyPath path;
    [SerializeField] private int currentIndex;
    [SerializeField] private bool isInReverse;
    [SerializeField] private Transform MeshHolder;
    private GameObject Player;

    [SerializeField] private float attackRadius;
    [SerializeField] private float detectionRadius;
    [SerializeField] private float damagesPower;
    [SerializeField] private float castcooldown;
    private float lastcast;

    public float AttackRadius
    {
        get { return attackRadius; }
    }

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");

        agent.SetDestination(path.GetSpotAt(currentIndex));
    }

    void Update()
    {
        
        
        if (Vector3.Distance(transform.position, path.GetSpotAt(currentIndex)) < 2f)
        {
            if (isInReverse)
            {
                currentIndex--;
                if (currentIndex <0)
                {
                    if (path.CanLoop)
                    {
                        currentIndex = path.PathLenth - 1;
                    }
                    else
                    {
                        currentIndex = 1;
                        isInReverse = false;
                    }
                }
            }
            else
            {
                currentIndex++;
                if(currentIndex>= path.PathLenth)
                {
                    if (path.CanLoop)
                    {
                        currentIndex = 0;
                    }
                    else
                    {
                        currentIndex = path.PathLenth - 2;
                        isInReverse = true;
                    }
                }
            }
            
            agent.SetDestination(path.GetSpotAt(currentIndex));
        }


        if (Player)
        {
            if (Vector3.Distance(transform.position, Player.transform.position) < detectionRadius)
            {
                agent.SetDestination(Player.transform.position);
            }
            else
            {
                agent.SetDestination(path.GetSpotAt(currentIndex));
            }

            if (lastcast + castcooldown <= Time.time && Vector3.Distance(transform.position, Player.transform.position) < attackRadius)
            {
                Player.GetComponent<Health>().ImpactHP(-damagesPower);
                lastcast = Time.time;
            }
        }
    }
}
