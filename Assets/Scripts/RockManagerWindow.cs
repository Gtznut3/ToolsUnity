using UnityEngine;
using UnityEditor;

public class RockManagerWindow : EditorWindow
{
    //public Vector3 SizeMap;
    public Material material;
    public int complexity = 1;
    public float spawnOffset = 0.1f;

    [MenuItem("Window/Rock Window")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow<RockManagerWindow>("Rock Manager");
    }

    private void OnGUI()
    {
        #region StylesCreation
        GUIStyle TitleStyle = new GUIStyle();
        TitleStyle.fontSize = 22;
        TitleStyle.fontStyle = FontStyle.Bold;
        TitleStyle.normal.textColor = Color.white;

        GUIStyle ErrorStyle = new GUIStyle();
        ErrorStyle.fontSize = 15;
        ErrorStyle.fontStyle = FontStyle.BoldAndItalic;
        ErrorStyle.normal.textColor = Color.red;
        #endregion

        #region RockGeneration
        EditorGUI.LabelField(new Rect(3, 1, position.width, 22), "Création Rock", TitleStyle);

        complexity = EditorGUI.IntField(new Rect(3, 25, position.width, 22), "Complexiter du rocher", complexity);
        material = EditorGUI.ObjectField(new Rect(3, 50, position.width, 22), "Material", material, typeof(Material), false) as Material;

        if (complexity < 1)
        {
            EditorGUI.LabelField(new Rect(3, 75, position.width, 20), "/!\\ La complexity ne peut pas être inférieur à 1 /!\\", ErrorStyle);
        }
        if (!material)
        {
            EditorGUI.LabelField(new Rect(3, 75, position.width, 20), "/!\\ Un matérial doit être sélectionné /!\\", ErrorStyle);
        }
        else
        {
            Rect buttonMap = new Rect(3, 150, position.width, 30);
            if (GUI.Button(buttonMap, "Créer Rock"))
            {
                SpawnRock();
            }
        }
        #endregion
    }

    private void SpawnRock()
    {
        GameObject Grouprock = new GameObject("RockCenter");
        if (complexity <= 1)
        {
            SpawnSingleRock(Grouprock);
            return;
        }

        for (int i = 0; i < complexity; i++)
        {
            SpawnSingleRock(Grouprock);
        }
    }

    private void SpawnSingleRock(GameObject Grouprock)
    {
        GameObject rock = GameObject.CreatePrimitive(PrimitiveType.Cube);
        Vector3 spawnPosition = Random.insideUnitSphere * spawnOffset;
        rock.transform.parent = Grouprock.transform;
        rock.transform.rotation = Quaternion.Euler(0, Random.Range(0.1f, 360f), 0);
        rock.transform.position = spawnPosition;
        rock.GetComponent<MeshRenderer>().material = material;
    }
}