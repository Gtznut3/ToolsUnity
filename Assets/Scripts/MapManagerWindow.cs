using UnityEngine;
using UnityEditor;

public class MapManagerWindow : EditorWindow
{
    static public GameObject RockPrefab;
    static public GameObject MapPrefab;
    static public GameObject MurPrefab;
    public Vector3 SizeMur;
    public Vector3 SizeMap;
    [MenuItem("Window/Map Window")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow<MapManagerWindow>("Map Manager");
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

        #region MapGeneration
        EditorGUI.LabelField(new Rect(3, 1, position.width, 22), "Création Map", TitleStyle);
        MapPrefab = EditorGUI.ObjectField(new Rect(3, 25, position.width, 20), "Prefab map", MapPrefab, typeof(GameObject), false) as GameObject;


        SizeMap = EditorGUI.Vector3Field(new Rect(3, 75, 200, 20), "SizeMap :", SizeMap);
        if (!MapPrefab)
        {
            EditorGUI.LabelField(new Rect(3, 50, position.width, 20), "/!\\ Pas de prefab choisi! /!\\", ErrorStyle);
        }
        else
        {
            Rect buttonMap = new Rect(3, 125, position.width, 30);
            if (GUI.Button(buttonMap, "Créer Map"))
            {
                CreateMap(SizeMap);
            }
        }
        #endregion

        #region Mur Generation
        EditorGUI.LabelField(new Rect(3, 150, position.width, 22), "Generation Mur", TitleStyle);
        MurPrefab = EditorGUI.ObjectField(new Rect(3, 175, position.width, 20), "Prefab mur", MurPrefab, typeof(GameObject), false) as GameObject;

        SizeMur = EditorGUI.Vector3Field(new Rect(3, 225, 200, 20), "SizeRock :", SizeMur);


        if (!MurPrefab)
        {
            EditorGUI.LabelField(new Rect(3, 200, position.width, 20), "/!\\ Pas de prefab choisi! /!\\", ErrorStyle);
        }
        else
        {
            Rect buttonRect = new Rect(3, 275, position.width, 30);
            if (GUI.Button(buttonRect, "Créer Mur"))
            {
                CreateMur(SizeMur);
            }
        }
        #endregion
    }

    private void CreateMur(Vector3 size)
    {
        GameObject newMur = GameObject.Instantiate(MurPrefab, null);

        newMur.transform.localScale = size;
    }

    private void CreateMap(Vector3 size)
    {
        GameObject newMap = GameObject.Instantiate(MapPrefab, null);

        newMap.transform.localScale = size;
    }
}
