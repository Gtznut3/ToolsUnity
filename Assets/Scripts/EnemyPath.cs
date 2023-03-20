using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class EnemyPath : MonoBehaviour
{
    [SerializeField] private List<Transform> spots;

    [SerializeField] private bool canLoop;

    public GameObject PrefabSpot;

    public int PathLenth
    {
        get
        {
            return spots.Count;
        }
    }

    public Vector3 GetSpotAt(int index)
    {
        return index < 0 || index >= spots.Count ? Vector3.zero : spots[index].position;
    }

    public bool CanLoop
    {
        get{return canLoop; }
    }
}
