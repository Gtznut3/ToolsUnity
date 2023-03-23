using UnityEditor;
using UnityEngine;

public class GroundManager : EditorWindow
{
    public GameObject groundPrefab;
    Vector3 newSize = Vector3.one;
    float height = 0;

    [MenuItem("Window/Sol Window")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow<GroundManager>("Sol Manager");
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
        EditorGUI.LabelField(new Rect(3, 1, position.width, 22), "Création d'un sol a hauteur désirez", TitleStyle);

        groundPrefab = EditorGUI.ObjectField(new Rect(3, 25, position.width, 20), "Prefab map", groundPrefab, typeof(GameObject), false) as GameObject;
        height = EditorGUI.FloatField(new Rect(3, 75, position.width, 22), "choissisez la hauteur", height);
        newSize = EditorGUI.Vector3Field(new Rect(3, 125, 200, 22), "choissisez la size de votre sol en X et Z", newSize);


        if (height < 1)
        {
            EditorGUI.LabelField(new Rect(3, 100, position.width, 20), "/!\\ La hauteur ne peut pas être inférieur à 1 /!\\", ErrorStyle);
        }
        else if (!groundPrefab)
        {
            EditorGUI.LabelField(new Rect(3, 50, position.width, 20), "/!\\ Pas de prefab choisi! /!\\", ErrorStyle);
        }
        else if (newSize.y != 1)
        {
            EditorGUI.LabelField(new Rect(3, 175, position.width, 20), "/!\\ Le sol ne peut pas avoir une size Y différente de 1 /!\\", ErrorStyle);
        }
        else
        {
            Rect buttonMap = new Rect(3, 175, position.width, 30);
            if (GUI.Button(buttonMap, "Créer un sol"))
            {
                SpawnGround();
            }
        }
        #endregion
    }
    public void SpawnGround()
    {

        GameObject ground = Instantiate(groundPrefab);


        Vector3 position = new Vector3(0, height, 0);
        ground.transform.position = position;
        ground.transform.localScale = newSize;
    }
}
