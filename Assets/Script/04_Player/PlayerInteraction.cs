using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private LayerMask interactableLayer;
    [SerializeField] private float range;
    private RaycastHit hitInfo;

    private IInformable targetinformable;
    private IInformable currentInformable;
    
    private Transform currentObject;

    private void Update()
    {
        // Raycast
        if (!Physics.Raycast(transform.position, transform.forward, out hitInfo, range, interactableLayer))
        {
            UIManager.Instance.informationUI?.OffInformation();
            UIManager.Instance.interactionUI?.OffGuide();
            currentInformable = null;
            currentObject = null;
            return;
        }

        currentObject = hitInfo.transform;

        // RayCast �浹�� IInformable ��������
        targetinformable = currentObject.GetComponent<IInformable>();

        // ĳ���ص� ������Ʈ�� ���� ������Ʈ�� �ƴ϶�� �ٽ� �Ҵ�
        if (currentInformable != targetinformable )
        {
            currentInformable = targetinformable;
            currentInformable?.Information();

            // IInteractable�� ��ӹ��� �ʴ� ������Ʈ ����ó��
            if (currentObject.TryGetComponent(out IInteractable interactable))
                interactable.InteractionText();
        }
    }



    public void OnInteraction(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            // ����ó�� 1
            if (currentObject == null)
                return;

            // IInteractable�� ��ӹ��� �ʴ� ������Ʈ ����ó��
            if(currentObject.TryGetComponent(out IInteractable interactable))
            {
                interactable.Interact();
            }
        }
    }

    private void CheckObject()
    {

    }
}
