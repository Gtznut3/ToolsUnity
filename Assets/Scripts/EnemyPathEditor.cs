using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(EnemyPath))]  //Indiquer la class modifiée dans l'inspecteur en la passant en paramètre de typeof()
class EnemyPathEditor : Editor
{
    public override void OnInspectorGUI()
    {
        EnemyPath path = (EnemyPath)target;

        Undo.RecordObject(path, "Change Path");
        if (GUILayout.Button("Add Spot"))
        {
            Transform newSpot = Instantiate(path.PrefabSpot, path.transform).transform;
            newSpot.position = path.GetSpotAt(path.PathLenth - 1) + new Vector3(Random.Range(-2, 2), 0, Random.Range(-2, 2));
            newSpot.gameObject.name = "Spot - " + (path.PathLenth + 1);
            path.AddSpot(newSpot);
        }

        if (GUILayout.Button("Clean Canceled Spots"))
        {
            for (int i = 0; i < path.transform.childCount; i++)
            {
                if (!path.SpotExistInList(path.transform.GetChild(i)))
                {
                    DestroyImmediate(path.transform.GetChild(i).gameObject);
                    i--;
                }
            }
        }

        GUILayout.Space(10);

        base.OnInspectorGUI();
    }
}
