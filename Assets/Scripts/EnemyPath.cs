using System.Collections;
using System.Collections.Generic;
using UnityEditor;
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

    public void AddSpot(Transform spot)
    {
        spots.Add(spot);
    }
    public bool CanLoop
    {
        get { return canLoop; }
    }

    public bool SpotExistInList(Transform spot)
    {
        return spots.Contains(spot);
    }

#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        foreach (Transform pos in spots)
        {
            Gizmos.DrawSphere(pos.position, 0.3f);
            Handles.Label(pos.position + (Vector3.up * 0.5f), new GUIContent(pos.gameObject.name));
        }

        if (spots.Count < 2) return;

        Handles.color = Color.red;
        for (int i = 0; i < spots.Count - 1; i++)
        {
            Handles.DrawAAPolyLine(spots[i].position, spots[i + 1].position);
        }

        if (canLoop)
        {
            Handles.color = Color.magenta;
            Handles.DrawAAPolyLine(spots[0].position, spots[spots.Count - 1].position);
        }
    }
#endif
}
