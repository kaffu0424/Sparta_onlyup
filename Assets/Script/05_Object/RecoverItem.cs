using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecoverItem : MonoBehaviour, IInteractable
{
    [SerializeField] private InteractionGuideData guideData;

    public void Interaction()
    {
        
    }

    public void InteractionText()
    {
        if (guideData == null)
            return;

        UIManager.Instance.interactionUI.UpdateGuide(guideData.objectGuide);
    }
}
