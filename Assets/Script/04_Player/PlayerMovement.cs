using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Animator animator { get; private set; }
    public Rigidbody rigidBody { get; private set; }

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

    [Header("PlayerData")]
    private Player playerData;

    public bool onLauncher;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        animator = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody>();

        onLauncher = false;

        playerData = PlayerManager.Instance.playerData;
        StartCoroutine(playerData.RecoverStamina());
    }

    private void FixedUpdate()
    {
        if (playerData.isDead)
            return;

        if (onLauncher)
            return;

        Move();
    }

    private void LateUpdate()
    {
        if (playerData.isDead)
            return;

        CameraLook();
    }

    private void Move()
    {
        Vector3 dir = transform.forward * curMovementInput.y + transform.right * curMovementInput.x;
        dir *= moveSpeed + playerData.buffValues[(int)BuffType.Speed];
        dir.y = rigidBody.velocity.y;

        rigidBody.velocity = dir;

        // 애니메이션
        animator.SetFloat("moveX", curMovementInput.x);
        animator.SetFloat("moveY", curMovementInput.y);
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
            curMovementInput = context.ReadValue<Vector2>();

        else if (context.phase == InputActionPhase.Canceled)
        { 
            curMovementInput = Vector2.zero;
        }
    }

    public void OnJumpInput(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started && CheckGrounded())
        {
            // 스테미나 부족하면 점프 X
            if (!playerData.UseStamina(10f))
                return;

            Vector3 jumpDir = Vector3.up * (jumpPower + playerData.buffValues[(int)BuffType.Jump]);
            rigidBody.AddForce(jumpDir, ForceMode.Impulse);
            animator.SetTrigger("Jump");
        }
    }

    private bool CheckGrounded()
    {
        // forward : 객체 앞
        // -forward : 객체 뒤
        // right : 객체 오른쪽
        // -right : 객체 왼쪽

        Ray[] rays = new Ray[4]
        {
            new Ray(transform.position + (transform.forward * 0.1f) + (transform.up * 0.01f), Vector3.down),
            new Ray(transform.position + (-transform.forward * 0.1f) + (transform.up * 0.01f), Vector3.down),
            new Ray(transform.position + (transform.right * 0.1f) + (transform.up * 0.01f), Vector3.down),
            new Ray(transform.position + (-transform.right * 0.1f) +(transform.up * 0.01f), Vector3.down)
        };

        for (int i = 0; i < rays.Length; i++)
        {
            if (Physics.Raycast(rays[i], 0.1f, groundLayerMask))
            {
                return true;
            }
        }
        return false;
    }

    
    private void OnCollisionEnter(Collision collision)
    {
        // 충돌했을때 Lanuncher 상태 false
        onLauncher = false;
    }
}
