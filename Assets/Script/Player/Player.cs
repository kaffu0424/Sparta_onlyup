using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Player
{
    public event Action<float, float> onHit;
    public event Action<float, float> onUseStamina;

    public float maxHP;
    public float hp;
    public float maxStamina;
    public float stamina;
    public bool isDead;

    public Player(float maxHP, float maxStamina)
    {
        this.maxHP = maxHP;
        hp = maxHP;
        isDead = false;
    }

    public void GetDamage(float damage)
    {
        hp -= damage;
        if(hp <= 0)
        {
            hp = 0;
            isDead = true;
        }

        onHit?.Invoke(maxHP, hp);
    }

}