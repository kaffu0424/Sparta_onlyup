using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : SIngleton<PlayerManager>
{
    public Player playerData { get; set; }
    public PlayerMovement playerMovement { get; private set; }
    public PlayerInteraction playerInteraction { get; private set; }
    public PlayerBuff playerBuff { get; private set; }
    protected override void InitializeManager()
    {
        // 캐싱
        playerMovement = FindObjectOfType<PlayerMovement>();    
        playerInteraction = FindObjectOfType<PlayerInteraction>();
        playerBuff = FindObjectOfType<PlayerBuff>();

        // 플레이어 데이터 생성
        // event 구독
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
