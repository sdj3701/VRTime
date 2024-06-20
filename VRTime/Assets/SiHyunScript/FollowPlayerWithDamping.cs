using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerWithDamping : MonoBehaviour
{
    public Transform player; // 플레이어 오브젝트의 Transform
    public Vector3 offset = new Vector3(1.0f, 0, 1.0f); // 플레이어 우측 앞쪽의 위치
    public float smoothTime = 0.3f; // 감쇠 시간

    private Vector3 velocity = Vector3.zero; // 속도 벡터

    void Start()
    {
        // 초기 위치 설정
        transform.position = player.position + player.TransformDirection(offset);
    }

    void Update()
    {
        // 목표 위치 계산
        Vector3 targetPosition = player.position + player.TransformDirection(offset);

        // 감쇠를 사용하여 원형 오브젝트 위치 업데이트
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}


