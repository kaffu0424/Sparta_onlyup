using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Player
{
    public float maxHP;
    public float hp;
    public bool isDead;

    public Player(float maxHP)
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

        UIManager.Instance.playerStat.UpdateHP(maxHP, hp);
    }
}