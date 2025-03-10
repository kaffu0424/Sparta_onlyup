using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class LaserTrap : MonoBehaviour
{
    private string playerTag = "Player";

    [SerializeField] private Transform laserTo;     // ������ ������
    [SerializeField] private Transform laserFrom;   // ���̴� ������

    private LineRenderer lineRenderer;              // ������ ���� ������
    private CapsuleCollider laserCollider;          // ������ �ݶ��̴�

    [SerializeField] private GameObject InteractionTarget;  // ��ȣ�ۿ� ���
    private IInteractReceiver interactReceiver;             // ��ȣ�ۿ� �������̽�
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

        // ������ ��ġ ( �߽� )
        Vector3 midPoint = (laserFrom.position + laserTo.position) / 2f;
        transform.position = midPoint;

        // ������ ���� / ����
        Vector3 direction = laserTo.position - laserFrom.position;
        float length = direction.magnitude;
        transform.rotation = Quaternion.LookRotation(direction);

        // �ݶ��̴� ũ��
        laserCollider.height = length;
        laserCollider.radius = lineRenderer.startWidth; // �ʿ信 ���� ����
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            interactReceiver?.OnInteraction();
        }
    }
}
