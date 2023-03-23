using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameOver : MonoBehaviour
{
    [SerializeField] private UnityEvent action;

    private void OnDisable()
    {
        action.Invoke();
    }
}
