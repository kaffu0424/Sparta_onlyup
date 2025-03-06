using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPanel : MonoBehaviour
{
    private const string playerTag = "Player";

    [SerializeField] private float power;
    private Vector2 jumpPower;

    private void Start()
    {
        jumpPower = new Vector2(0, power);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag(playerTag))
        {
            PlayerManager.Instance.playerMovement.rigidBody.AddForce(jumpPower, ForceMode.Impulse);
        }
    }
}
