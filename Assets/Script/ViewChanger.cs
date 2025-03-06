using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ViewChanger : MonoBehaviour
{
    [SerializeField] private GameObject fpv;    // 1��Ī ī�޶�
    [SerializeField] private GameObject tpv;    // 3��Ī ī�޶�


    public void OnChangeViewType(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            tpv.SetActive(!tpv.activeSelf);
            fpv.SetActive(!fpv.activeSelf);
        }
    }
}
