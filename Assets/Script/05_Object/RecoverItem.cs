using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecoverItem : MonoBehaviour, IInteractable
{
    [SerializeField] private InteractionGuideData guideData;
    [SerializeField] private RecoverData recoverData;

    public void Interaction()
    {
        float value = recoverData.value;
        StatType type = recoverData.type;
        PlayerManager.Instance.playerData.Recover(value, type);

        Destroy(gameObject);
    }

    public void InteractionText()
    {
        if (guideData == null)
            return;

        UIManager.Instance.interactionUI.UpdateGuide(guideData.objectGuide);
    }
}
