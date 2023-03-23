using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime.Misc;

public class RecoltableManager : MonoBehaviour
{

    [SerializeField] private List<Recoltable> list = new List<Recoltable>();
    private int cpt = 0;
    [SerializeField] TextMeshProUGUI labelCPT;
    public GameObject prefab;
    public int listLenth
    {
        get
        {
            return list.Count;
        }
    }

    private void Start()
    {
        labelCPT.text = cpt + " / " + (list.Count + cpt);

    }

    public void AddRecoltable(Recoltable r)
    {
        list.Add(r);
        labelCPT.text = cpt + " / " + (list.Count + cpt);
    }

    public void RemoveRecoltable(Recoltable r)
    {
        list.Remove(r);
        cpt++;
        labelCPT.text = cpt + " / " + (list.Count + cpt);
    }

    public bool SpotExistInList(Recoltable recoltable)
    {
        return list.Contains(recoltable);
    }

    public Transform GetLastRecoltableTransform()
    {
        return list[listLenth - 1].transform;
    }

}