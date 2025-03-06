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

        // RayCast 충돌한 IInformable 가져오기
        hitTarget = hitInfo.transform.GetComponent<IInformable>();

        // 캐싱해둔 오브젝트와 같은 오브젝트이 아니라면 다시 호출하기
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
