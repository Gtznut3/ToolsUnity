using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GizmoEnemy : MonoBehaviour
{
    [SerializeField] private EnemyScript enemy;
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, enemy.AttackRadius);
    }
}
