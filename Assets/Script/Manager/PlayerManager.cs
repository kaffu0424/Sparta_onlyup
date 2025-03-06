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
