using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Player
{
    Action<float, float> hitEvent;

    public float maxHP;
    public float hp;
    public bool isDead;

    public Player(float maxHP, Action<float, float> hitEvent)
    {
        this.maxHP = maxHP;
        hp = maxHP;
        isDead = false;

        this.hitEvent = hitEvent;
    }

    public void GetDamage(float damage)
    {
        hp -= damage;
        if(hp <= 0)
        {
            hp = 0;
            isDead = true;
        }

        hitEvent?.Invoke(maxHP, hp);
    }
}