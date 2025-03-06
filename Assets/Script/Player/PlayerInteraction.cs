using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private LayerMask interactableLayer;
    [SerializeField] private float range;
    private RaycastHit hitInfo;

    private IInformable hitTarget;
    private IInformable currentInteractable;

    private Transform currentObject;

    private void Update()
    {
        // Raycast
        if (!Physics.Raycast(transform.position, transform.forward, out hitInfo, range, interactableLayer))
        {
            UIManager.Instance.informationUI?.OffInformation();
            currentInteractable = null;
            currentObject = null;
            return;
        }

        currentObject = hitInfo.transform;

        // RayCast �浹�� IInformable ��������
        hitTarget = currentObject.GetComponent<IInformable>();

        // ĳ���ص� ������Ʈ�� ���� ������Ʈ�� �ƴ϶�� �ٽ� �Ҵ��ؼ� ȣ��
        if (currentInteractable != hitTarget)
        {
            currentInteractable = hitTarget;
            currentInteractable.Information();
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
                interactable.Interaction();
            }
        }
    }

    private void CheckObject()
    {

    }
}
