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
        // �ʿ��� ���׹̳����� ������
        if (stamina < useStamina)
            return false;

        // ���׹̳� ����
        stamina -= useStamina;

        // ����ڵ�
        if (stamina <= 0)
            stamina = 0;
        onUseStamina?.Invoke(maxStamina, stamina);
        return true;
    }

    public IEnumerator RecoverStamina()
    {
        while(true)
        {
            // ���׹̳��� �ִ� ���׹̳����� ������������ ���
            yield return new WaitWhile(() => stamina >= maxStamina);

            // ���׹̳� ȸ��
            stamina += Time.deltaTime;

            // ���׹̳� ������ ������Ʈ
            // �̺κ� �ʹ� ���ſ�Ű�����..
            onUseStamina?.Invoke(maxStamina, stamina);

            yield return null;
        }
    }
}