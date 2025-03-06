using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : SIngleton<PlayerManager>
{
    [SerializeField] public Player playerData { get; private set; }
    [SerializeField] public PlayerMovement playerMovement { get; private set; }
    [SerializeField] public PlayerInteraction playerInteraction { get; private set; }
    protected override void InitializeManager()
    {
        // �÷��̾� ������Ʈ�� PlayerMovement / PlayerInteraction ã��
        playerMovement = FindObjectOfType<PlayerMovement>();    
        playerInteraction = FindObjectOfType<PlayerInteraction>();

        // �÷��̾� ������ ����
        // event ����
        playerData = new Player(100,200);
        playerData.onHit += OnHit;
        playerData.onUseStamina += UseStamina;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
            playerData.GetDamage(10);
    }

    private void OnHit(float maxHp, float hp)
    {
        UIManager.Instance.playerStatUI.UpdateStat(maxHp, hp, StatType.Hp);
    }

    private void UseStamina(float maxStamina, float stamina)
    {
        UIManager.Instance.playerStatUI.UpdateStat(maxStamina, stamina, StatType.Stamina);
    }
}
