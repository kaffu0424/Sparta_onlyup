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
        this.maxStamina = maxStamina;

        hp = maxHP;
        stamina = maxStamina;

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

    public bool UseStamina(float useStamina)
    {
        // 필요한 스테미나보다 적을때
        if (stamina < useStamina)
            return false;

        // 스테미나 감소
        stamina -= useStamina;

        // 방어코드
        if (stamina <= 0)
            stamina = 0;
        onUseStamina?.Invoke(maxStamina, stamina);
        return true;
    }

    public IEnumerator RecoverStamina()
    {
        while(true)
        {
            // 스테미나가 최대 스테미나보다 낮아질때까지 대기
            yield return new WaitWhile(() => stamina >= maxStamina);

            // 스테미나 회복
            stamina += Time.deltaTime;

            // 스테미나 게이지 업데이트
            // 이부분 너무 무거운거같은데..
            onUseStamina?.Invoke(maxStamina, stamina);

            yield return null;
        }
    }
}