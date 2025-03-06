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
        // 플레이어 오브젝트의 PlayerMovement / PlayerInteraction 찾기
        playerMovement = FindObjectOfType<PlayerMovement>();    
        playerInteraction = FindObjectOfType<PlayerInteraction>();

        // 플레이어 데이터 생성
        playerData = new Player(100, HitEvent);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
            playerData.GetDamage(10);
    }

    private void HitEvent(float maxHp, float hp)
    {
        UIManager.Instance.playerStat.UpdateHP(maxHp, hp);
    }
}
