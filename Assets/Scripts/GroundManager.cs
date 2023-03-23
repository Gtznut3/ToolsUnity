using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class GroundManager : EditorWindow
{
    public GameObject groundPrefab;
    public GameObject RampePrefab;
    Vector3 newSize = Vector3.one;
    List<string> rampname = new List<string>();
    float height = 0;
    int nbrderamp = 1;

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

        groundPrefab = EditorGUI.ObjectField(new Rect(3, 25, position.width, 20), "Prefab sol", groundPrefab, typeof(GameObject), false) as GameObject;
        nbrderamp = EditorGUI.IntField(new Rect(3, 75, position.width, 22), "nombre de ramp", nbrderamp);
        height = EditorGUI.FloatField(new Rect(3, 125, position.width, 22), "choissisez la hauteur", height);

        if (height < 1)
        {
            EditorGUI.LabelField(new Rect(3, 150, position.width, 20), "/!\\ La hauteur ne peut pas être inférieur à 1 /!\\", ErrorStyle);
        }
        else if (!groundPrefab)
        {
            EditorGUI.LabelField(new Rect(3, 50, position.width, 20), "/!\\ Pas de prefab de sol choisi! /!\\", ErrorStyle);
        }
        else if (nbrderamp < 0 || nbrderamp > 4)
        {
            EditorGUI.LabelField(new Rect(3, 100, position.width, 20), "/!\\ Pas plus de 4 ramp et moins de 0! /!\\", ErrorStyle);
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
        GameObject rampe;
        rampname.Add("Rampe Right");
        rampname.Add("Rampe Left");
        rampname.Add("Rampe Forward");
        rampname.Add("Rampe Backward");

        Vector3 positionsol = new Vector3(0, height, 0);
        ground.transform.position = positionsol;

        for (int i = 0; i < (4 - nbrderamp); i++) 
        {
            rampe = ground.transform.Find(rampname[i]).gameObject;
            rampe.SetActive(false);
        }
    }
}
