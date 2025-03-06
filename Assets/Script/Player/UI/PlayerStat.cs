using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : MonoBehaviour
{
    private PlayerHPBar hpbar;
    // private PlayerStamina stamina

    private void Start()
    {
        hpbar = GetComponentInChildren<PlayerHPBar>();
    }

    public void UpdateHP(float maxHp, float currenthp)
    {
        hpbar.SetHPbar(maxHp, currenthp);
    }
}
