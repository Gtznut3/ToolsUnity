using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceRot : MonoBehaviour
{
    [SerializeField] private Vector3 rot;
    void Update()
    {
        transform.eulerAngles = rot;
    }
}
