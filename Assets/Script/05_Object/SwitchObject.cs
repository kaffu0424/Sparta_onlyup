using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchObject : MonoBehaviour, IInteractable
{
    [SerializeField] private InteractionGuideData guideData;
    private InteractionUI interactionUI;

    [SerializeField] private GameObject InteractionTarget;  // ����ġ ��ȣ�ۿ� ���
    [SerializeField] private Transform switchTransform;     // ����ġ ��ư Transform
    [SerializeField] private Vector3 moveOffset;            // ����ġ ��ư �����̴� ����

    private Vector3 movePosition;
    private bool onSwitch;

    private IInteractReceiver interactReceiver;
    void Start()
    {
        interactionUI = UIManager.Instance.interactionUI;
        interactReceiver = InteractionTarget.GetComponent<IInteractReceiver>();

        movePosition = switchTransform.position + moveOffset;
        onSwitch = false;
    }

    public void Interact()
    {
        if (onSwitch)
            return;

        switchTransform.DOMove(movePosition, 0.5f)
            .SetEase(Ease.Linear).SetLoops(2, LoopType.Yoyo);

        interactReceiver.OnInteraction();

        onSwitch = true;
    }

    public void InteractionText()
    {
        if (guideData == null)
            return;

        interactionUI.UpdateGuide(guideData.objectGuide);
    }
}
