using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MovePanel : MonoBehaviour
{
    private const string playerTag = "Player";

    [SerializeField] private Transform fromTransform;
    [SerializeField] private Transform toTransform;

    [SerializeField] private float moveTime;
    void Start()
    {
        transform.position = fromTransform.position;

        transform.DOMove(toTransform.position, moveTime)
            .SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag(playerTag))
        {
            collision.transform.parent = transform;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag(playerTag))
        {
            collision.transform.parent = null;
        }
    }
}
