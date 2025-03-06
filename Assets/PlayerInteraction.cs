using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] LayerMask interactableLayer;
    private RaycastHit hitInfo;

    IInformable hitTarget;
    IInformable currentInteractable;

    private void Update()
    {
        if (!Physics.Raycast(transform.position, transform.forward, out hitInfo, 10f, interactableLayer))
        {
            UIManager.Instance.informationUI?.OffInformation();
            currentInteractable = null;
            return;
        }

        // RayCast �浹�� IInformable ��������
        hitTarget = hitInfo.transform.GetComponent<IInformable>();

        // ĳ���ص� ������Ʈ�� ���� ������Ʈ�� �ƴ϶�� �ٽ� ȣ���ϱ�
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

        }
    }

    private void CheckObject()
    {

    }
}
