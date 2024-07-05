using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    public GameObject targetObject; // 이동할 오브젝트
    public float moveDistance = 5.0f; // 이동할 거리
    public float smoothTime = 0.3f; // 이동 속도를 제어하는 시간 상수

    private Vector3 originalPosition;
    private Vector3 targetPosition;
    private Vector3 velocity = Vector3.zero; // SmoothDamp에서 사용할 속도 변수
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
        if (other.CompareTag("Player")) // 플레이어의 태그가 "Player"라고 가정
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
