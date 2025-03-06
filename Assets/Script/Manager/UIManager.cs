using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : SIngleton<UIManager>
{
    public PlayerStatUI playerStatUI { get; private set; }
    public InformationUI informationUI { get; private set; }
    protected override void InitializeManager()
    {
        playerStatUI = FindObjectOfType<PlayerStatUI>();
        informationUI = FindObjectOfType<InformationUI>();
    }
}
