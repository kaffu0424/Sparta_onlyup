using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ViewChanger : MonoBehaviour
{
    [SerializeField] private GameObject fpv;    // 1인칭 카메라
    [SerializeField] private GameObject tpv;    // 3인칭 카메라
    [SerializeField] private GameObject crosshair;   // 

    public void OnChangeViewType(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            fpv.SetActive(!fpv.activeSelf);
            tpv.SetActive(!tpv.activeSelf);

            crosshair.SetActive(fpv.activeSelf);
        }
    }
}
