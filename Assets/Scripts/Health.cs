using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private Image lifeBar;
    [SerializeField] private float HPmax;
    private float HP;

    void Start()
    {
        HP = HPmax;
    }

    public void ImpactHP(float value)
    {
        HP += value;
        lifeBar.fillAmount = HP / HPmax;

        if (HP <= 0) // Plus de hp, meurt.
        {
            Destroy(gameObject);
        }

        if(HP> HPmax)// Trop de hp.
        {
            HP = HPmax;
        }
    }
}
