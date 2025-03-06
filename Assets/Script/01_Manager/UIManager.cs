using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : SIngleton<UIManager>
{
    public PlayerStatUI playerStatUI { get; private set; }
    public InformationUI informationUI { get; private set; }
    public InteractionUI interactionUI { get; private set; }

    protected override void InitializeManager()
    {
        // Ä³½Ì
        playerStatUI = FindObjectOfType<PlayerStatUI>();
        informationUI = FindObjectOfType<InformationUI>();
        interactionUI = FindObjectOfType<InteractionUI>();
    }
}
