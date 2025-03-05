using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : SIngleton<PlayerManager>
{
    [SerializeField] public Player playerData { get; private set; }
    [SerializeField] public PlayerMovement playerMovement { get; private set; }

    protected override void InitializeManager()
    {
        // �÷��̾� ������Ʈ�� PlayerMovement ã��
        playerMovement = FindObjectOfType<PlayerMovement>();    

        // �÷��̾� ������ ����
        playerData = new Player(100);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
            playerData.GetDamage(10);
    }
}
