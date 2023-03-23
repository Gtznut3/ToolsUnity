using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(RecoltableManager))]
public class RecoltableEditor : Editor
{
    public override void OnInspectorGUI()
    {
        RecoltableManager recoltable = (RecoltableManager)target;

        Undo.RecordObject(recoltable, "ChangeRecoltable");
        if (GUILayout.Button("Add Recoltable"))
        {
            Transform newRecolctable = Instantiate(recoltable.prefab, recoltable.transform).transform;
            newRecolctable.position = recoltable.GetLastRecoltableTransform().position + new Vector3(Random.Range(-2, 2), 0, Random.Range(-2, 2));
            newRecolctable.gameObject.name = "Element " + (recoltable.listLenth + 1);
            recoltable.AddRecoltable(newRecolctable.GetComponent<Recoltable>());
        }

        if (GUILayout.Button("Clear Canceled Recoltable"))
        {
            for (int i = 0; i < recoltable.transform.childCount; i++)
            {
                if (!recoltable.SpotExistInList(recoltable.transform.GetChild(i).GetComponent<Recoltable>()))
                {
                    DestroyImmediate(recoltable.transform.GetChild(i).gameObject);
                    i--;
                }
            }
        }

        base.OnInspectorGUI();
    }
}