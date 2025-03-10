using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecoverItem : MonoBehaviour, IInteractable
{
    [SerializeField] private InteractionGuideData guideData;
    [SerializeField] private RecoverData recoverData;

    private InteractionUI interactionUI;
    private Player playerData;
    private void Start()
    {
        interactionUI = UIManager.Instance.interactionUI;
        playerData = PlayerManager.Instance.playerData;
    }

    public void Interact()
    {
        if(recoverData == null)
        {
            Destroy(gameObject);
            return;
        }

        float value = recoverData.value;
        StatType type = recoverData.type;
        playerData.Recover(value, type);

        Destroy(gameObject);
    }

    public void InteractionText()
    {
        if (guideData == null)
            return;

        interactionUI.UpdateGuide(guideData.objectGuide);
    }
}
