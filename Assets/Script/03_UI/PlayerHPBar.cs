using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHPBar : MonoBehaviour
{
    [SerializeField] private Image hpFill;

    public void SetHPbar(float maxHp, float currenthp)
    {
        hpFill.fillAmount = currenthp / maxHp;
    }
}
