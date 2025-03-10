using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BuffType
{
    Speed,
    Jump
}

public class BuffItem : MonoBehaviour, IInteractable
{
    [SerializeField] private InteractionGuideData guideData;
    [SerializeField] private BuffData buffData;

    private InteractionUI interactionUI;
    private PlayerBuff playerBuff;
    private void Start()
    {
        interactionUI = UIManager.Instance.interactionUI;
        playerBuff = PlayerManager.Instance.playerBuff;
    }

    public void Interact()
    {
        if (buffData == null)
        {
            Destroy(gameObject);
            return;
        }

        playerBuff.UseBuff(buffData);

        Destroy(gameObject);
    }

    public void InteractionText()
    {
        if (guideData == null)
            return;

        interactionUI.UpdateGuide(guideData.objectGuide);
    }
}
