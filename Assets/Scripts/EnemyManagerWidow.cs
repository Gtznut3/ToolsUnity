using UnityEngine;
using UnityEditor;

public class EnemyManagerWindow : EditorWindow
{
    string[] options = { "Classic", "Small", "Big" };
    int index = 0;
    static public EnemyStats desiredStats;
    static public GameObject enemyPrefab;

    [MenuItem("Window/Enemy Manager Window")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow<EnemyManagerWindow>("Enemy Manager");
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

        #region ModifStats
        EditorGUI.LabelField(new Rect(3, 1, position.width, 22), "MODIFICATIONS STATS", TitleStyle);

        EditorGUI.LabelField(new Rect(3, 25, position.width, 20), "Selectionne les ennemis que tu souhaites modifier, puis appuis sur le bouton.", EditorStyles.boldLabel);

        desiredStats = EditorGUI.ObjectField(new Rect(3, 50, position.width, 20), "Stats désirées", desiredStats, typeof(EnemyStats), false) as EnemyStats;

        if (!desiredStats)
        {
            EditorGUI.LabelField(new Rect(3, 75, position.width, 20), "/!\\ Aucune ScriptableObject EnemyStats choisie! /!\\", ErrorStyle);
        }
        else
        {
            if (!CheckForEnemiesInSelection())
            {
                EditorGUI.LabelField(new Rect(3, 75, position.width, 20), "/!\\ Aucun EnemyScript séléctionné dans la scene! /!\\", ErrorStyle);
            }
            else
            {
                Rect buttonRect = new Rect(3, 75, position.width, 30);
                if (GUI.Button(buttonRect, "Changer stats pour ->" + desiredStats.name + "<-"))
                {
                    ChangeStatsOfSelectedEnemies();
                }
            }
        }
        #endregion

        #region Enemy Generation
        EditorGUI.LabelField(new Rect(3, 150, position.width, 22), "GENERATION D'ENNEMIS", TitleStyle);

        EditorGUI.LabelField(new Rect(3, 175, position.width, 20), "Selectionne un EnemyPath, puis appuis sur le bouton.", EditorStyles.boldLabel);

        enemyPrefab = EditorGUI.ObjectField(new Rect(3, 200, position.width, 20), "Prefab Enemy", enemyPrefab, typeof(GameObject), false) as GameObject;

        if (!enemyPrefab)
        {
            EditorGUI.LabelField(new Rect(3, 225, position.width, 20), "/!\\ Pas de prefab choisi! /!\\", ErrorStyle);
        }
        else if (!enemyPrefab.GetComponent<EnemyScript>())
        {
            EditorGUI.LabelField(new Rect(3, 225, position.width, 20), "/!\\ Le prefab n'est pas un Enemy! /!\\", ErrorStyle);
        }
        else if (CheckForPathInSelection() > 1)
        {
            EditorGUI.LabelField(new Rect(3, 225, position.width, 20), "/!\\ Trop d'EnemyPath séléctionnés! /!\\", ErrorStyle);
        }
        else if (CheckForPathInSelection() == 0)
        {
            EditorGUI.LabelField(new Rect(3, 225, position.width, 20), "/!\\ Aucun EnemyPath séléctionné! /!\\", ErrorStyle);
        }
        else
        {
            Rect buttonRect = new Rect(3, 225, position.width, 30);
            if (GUI.Button(buttonRect, "Créer Enemy"))
            {
                CreateEnemyOnSelectedsPath();
            }
        }
        #endregion
    }

    private bool CheckForEnemiesInSelection()
    {
        bool res = false;
        foreach (GameObject obj in Selection.gameObjects)
        {
            if (obj.GetComponent<EnemyScript>())
            {
                return true;
            }
        }
        return res;
    }

    private int CheckForPathInSelection()
    {
        int nbOfPath = 0;
        foreach (GameObject obj in Selection.gameObjects)
        {
            if (obj.GetComponent<EnemyPath>())
            {
                nbOfPath++;
            }
        }
        return nbOfPath;
    }

    private void ChangeStatsOfSelectedEnemies()
    {
        if (!CheckForEnemiesInSelection()) return;

        foreach (GameObject obj in Selection.gameObjects)
        {
            EnemyScript es = obj.GetComponent<EnemyScript>();

            if (es)
            {
                es.SwapStats(desiredStats);
            }
        }
    }

    private void CreateEnemyOnSelectedsPath()
    {
        EnemyPath path = null;
        foreach (GameObject obj in Selection.gameObjects)
        {
            if (obj.GetComponent<EnemyPath>())
            {
                path = obj.GetComponent<EnemyPath>();
                GameObject newEnemy = GameObject.Instantiate(enemyPrefab, null);
                int rdmIndex = Random.Range(0, path.PathLenth);
                newEnemy.transform.position = path.GetSpotAt(rdmIndex) + new Vector3(Random.Range(-2, 2), 1, Random.Range(-2, 2));
                newEnemy.GetComponent<EnemyScript>().SetPath(path, rdmIndex);

                if (desiredStats)
                {
                    newEnemy.GetComponent<EnemyScript>().SwapStats(desiredStats);
                }
            }
        }


    }

}
