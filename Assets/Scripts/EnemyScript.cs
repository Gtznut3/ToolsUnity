using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
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

    //[SerializeField] private float attackRadius;
    //[SerializeField] private float detectionRadius;
    //[SerializeField] private float damagesPower;
    //[SerializeField] private float castcooldown;
    private float lastcast;

    [SerializeField] private EnemyStats stats;

    public float AttackRadius
    {
        get { return stats.attackRadius; }
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
            if (Vector3.Distance(transform.position, Player.transform.position) < stats.detectionRadius)
            {
                agent.SetDestination(Player.transform.position);
            }
            else
            {
                agent.SetDestination(path.GetSpotAt(currentIndex));
            }

            if (lastcast + stats.castcooldown <= Time.time && Vector3.Distance(transform.position, Player.transform.position) < stats.attackRadius)
            {
                Player.GetComponent<Health>().ImpactHP(-stats.damagesPower);
                lastcast = Time.time;
            }
        }
    }

    public void UpdateComponents()
    {
        GetComponentInChildren<MeshRenderer>().material = stats.meshColor;
        MeshHolder.localScale = Vector3.one * stats.size;
        agent.speed = stats.speed;
    }

    public void SwapStats(EnemyStats newStats)
    {
        stats = newStats;
        UpdateComponents();
    }

    public void SetPath(EnemyPath newPath, int newIndex)
    {
        path = newPath;
        currentIndex = newIndex;
    }
}
