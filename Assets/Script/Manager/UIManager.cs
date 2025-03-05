using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : SIngleton<UIManager>
{
    public PlayerStat playerStat { get; private set; }

    protected override void InitializeManager()
    {
        playerStat = FindObjectOfType<PlayerStat>();
    }
}
