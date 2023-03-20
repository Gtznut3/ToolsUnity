using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class RecoltableManager : MonoBehaviour
{

    [SerializeField] private List<Recoltable> list = new List<Recoltable>();
    private int cpt = 0;
    [SerializeField] TextMeshProUGUI labelCPT;

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

}
