using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
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

    [SerializeField] private bool isGrounded;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody>();

        Cursor.lockState = CursorLockMode.Locked;

        isGrounded = true;
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

        // ¾Ö´Ï¸ÞÀÌ¼Ç
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
        // ¶¥¿¡ ÀÖ´Â»óÅÂ°¡ ¾Æ´Ò¶§ ¿òÁ÷ÀÓ ¹æÁö
        if (!isGrounded)
            return;

        if (context.phase == InputActionPhase.Performed)
            curMovementInput = context.ReadValue<Vector2>();

        else if (context.phase == InputActionPhase.Canceled)
            curMovementInput = Vector2.zero;
    }
    public void OnJumpInput(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Started && CheckGrounded())
        {
            rigidBody.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
            animator.SetTrigger("Jump");
            animator.SetBool("Landing", false);
            StartCoroutine(CheckLanding());
        }
    }

    private bool CheckGrounded()
    {
        // forward : °´Ã¼ ¾Õ
        // -forward : °´Ã¼ µÚ
        // right : °´Ã¼ ¿À¸¥ÂÊ
        // -right : °´Ã¼ ¿ÞÂÊ

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

    private IEnumerator CheckLanding()
    {
        isGrounded = false;
        yield return new WaitForSeconds(0.02f);

        while (!isGrounded)
        {
            yield return null;
            if(CheckGrounded())
            {
                isGrounded = true;
                animator.SetBool("Landing", true);

                curMovementInput = Vector2.zero;
            }
        }
    }
}
