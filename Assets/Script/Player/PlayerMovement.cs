using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Animator animator;
    private Rigidbody rigidBody;

    [Header("movement")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpPower;
    [SerializeField] private LayerMask groundLayerMask;
    private Vector2 curMovementInput;

    [Header("Look")]
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private float minXLook;
    [SerializeField] private float maxXLook;
    [SerializeField] private float lookSensitivity;
    private float camCurXRot;
    private Vector2 mouseDelta;

    [HideInInspector]
    public bool canLook = true;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody>();

        Cursor.lockState = CursorLockMode.Locked;
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void LateUpdate()
    {
        CameraLook();
    }

    private void Move()
    {
        Vector3 dir = transform.forward * curMovementInput.y + transform.right * curMovementInput.x;
        dir *= moveSpeed;
        dir.y = rigidBody.velocity.y;

        rigidBody.velocity = dir;
    }

    void CameraLook()
    {
        camCurXRot += mouseDelta.y * lookSensitivity;
        camCurXRot = Mathf.Clamp(camCurXRot, minXLook, maxXLook);
        cameraTransform.localEulerAngles = new Vector3(-camCurXRot, 0, 0);

        transform.eulerAngles += new Vector3(0, mouseDelta.x * lookSensitivity, 0);
    }

    public void OnLookInput(InputAction.CallbackContext context)
    {
        mouseDelta = context.ReadValue<Vector2>();
    }
    public void OnMoveInput(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            curMovementInput = context.ReadValue<Vector2>();

            // y < 0  ( 뒤로 걷는 애니메이션
            // y >= 0 ( 앞으로 걷는 애니메이션
        }
        else if (context.phase == InputActionPhase.Canceled)
        {
            curMovementInput = Vector2.zero;
        }
    }
    public void OnJumpInput(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Started)
        {
            rigidBody.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
        }
    }
}
