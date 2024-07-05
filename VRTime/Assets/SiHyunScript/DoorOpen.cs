using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    public GameObject targetObject; // �̵��� ������Ʈ
    public float moveDistance = 5.0f; // �̵��� �Ÿ�
    public float smoothTime = 0.3f; // �̵� �ӵ��� �����ϴ� �ð� ���

    private Vector3 originalPosition;
    private Vector3 targetPosition;
    private Vector3 velocity = Vector3.zero; // SmoothDamp���� ����� �ӵ� ����
    private bool shouldMoveUp = false;
    private bool shouldMoveDown = false;

    void Start()
    {
        if (targetObject != null)
        {
            originalPosition = targetObject.transform.position;
        }
    }

    void Update()
    {
        if (targetObject != null)
        {
            if (shouldMoveUp)
            {
                targetPosition = originalPosition + Vector3.up * moveDistance;
                targetObject.transform.position = Vector3.SmoothDamp(targetObject.transform.position, targetPosition, ref velocity, smoothTime);
            }
            else if (shouldMoveDown)
            {
                targetPosition = originalPosition;
                targetObject.transform.position = Vector3.SmoothDamp(targetObject.transform.position, targetPosition, ref velocity, smoothTime);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // �÷��̾��� �±װ� "Player"��� ����
        {
            shouldMoveUp = true;
            shouldMoveDown = false;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            shouldMoveUp = false;
            shouldMoveDown = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        
    }
}
