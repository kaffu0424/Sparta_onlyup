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

        // RayCast 충돌한 IInformable 가져오기
        hitTarget = currentObject.GetComponent<IInformable>();

        // 캐싱해둔 오브젝트와 같은 오브젝트이 아니라면 다시 할당해서 호출
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
            // 예외처리 1
            if (currentObject == null)
                return;

            // IInteractable을 상속받지 않는 오브젝트 예외처리
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
