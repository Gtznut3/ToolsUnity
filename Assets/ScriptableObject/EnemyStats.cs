using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New EnemyStats", menuName = "EnemyStats")]
public class EnemyStats : ScriptableObject
{
    public new string name;
    public Material meshColor;
    public float attackRadius;
    public float speed;
    public float size;
    public float detectionRadius;
    public float damagesPower;
    public float castcooldown;
}
