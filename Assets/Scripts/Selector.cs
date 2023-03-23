using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;

public class Selector : EditorWindow
{

    [MenuItem("Window/Selector")]

    public static void ShowWindow()
    {
        EditorWindow.GetWindow<Selector>("Selector");
    }

    private void OnGUI()
    {
        Rect buttonRect = new Rect(3, 30, position.width, 30);
        if (GUI.Button(buttonRect, "Selectionner le joueur, la cam et le start"))
        {
            startSelection();
        }
    }

    private void startSelection()
    {
        Object[] objects = new Object[3];
        objects[0] = (Object)GameObject.FindGameObjectWithTag("Player");
        objects[1] = (Object)GameObject.FindGameObjectWithTag("MainCamera");
        objects[2] = (Object)GameObject.FindGameObjectWithTag("Start");

        Selection.objects = objects;
    }
}

