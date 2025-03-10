using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class LaserTrap : MonoBehaviour
{
    private string playerTag = "Player";

    [SerializeField] private Transform laserTo;     // 레이저 시작점
    [SerializeField] private Transform laserFrom;   // 레이더 도착점

    private LineRenderer lineRenderer;              // 레이저 라인 렌더러
    private CapsuleCollider laserCollider;          // 레이저 콜라이더

    [SerializeField] private GameObject InteractionTarget;  // 상호작용 대상
    private IInteractReceiver interactReceiver;             // 상호작용 인터페이스
    private void Start()
    {
        if(InteractionTarget != null)
            interactReceiver = InteractionTarget.GetComponent<IInteractReceiver>();

        SetLine();
        SetCollider();
    }

    private void SetLine()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.SetPosition(0, laserTo.position);
        lineRenderer.SetPosition(1, laserFrom.position);
    }

    private void SetCollider()
    {
        laserCollider = gameObject.AddComponent<CapsuleCollider>();
        laserCollider.isTrigger = true;
        laserCollider.direction = 2;

        // 레이저 위치 ( 중심 )
        Vector3 midPoint = (laserFrom.position + laserTo.position) / 2f;
        transform.position = midPoint;

        // 레이저 방향 / 길이
        Vector3 direction = laserTo.position - laserFrom.position;
        float length = direction.magnitude;
        transform.rotation = Quaternion.LookRotation(direction);

        // 콜라이더 크기
        laserCollider.height = length;
        laserCollider.radius = lineRenderer.startWidth; // 필요에 따라 조절
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            interactReceiver?.OnInteraction();
        }
    }
}
