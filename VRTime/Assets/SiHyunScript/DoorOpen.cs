using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    public Transform leftDoor; // 왼쪽 문 오브젝트의 Transform
    public Transform rightDoor; // 오른쪽 문 오브젝트의 Transform

    public Vector3 leftDoorOpenLocalPosition; // 왼쪽 문이 열렸을 때의 로컬 위치
    public Vector3 leftDoorClosedLocalPosition; // 왼쪽 문이 닫혔을 때의 로컬 위치
    public Vector3 rightDoorOpenLocalPosition; // 오른쪽 문이 열렸을 때의 로컬 위치
    public Vector3 rightDoorClosedLocalPosition; // 오른쪽 문이 닫혔을 때의 로컬 위치

    public float speed = 2.0f; // 문이 이동하는 속도

    private Vector3 leftDoorTargetLocalPosition; // 왼쪽 문의 목표 로컬 위치
    private Vector3 rightDoorTargetLocalPosition; // 오른쪽 문의 목표 로컬 위치

    void Start()
    {
        leftDoorTargetLocalPosition = leftDoorClosedLocalPosition; // 초기에는 왼쪽 문을 닫힌 상태로 설정
        rightDoorTargetLocalPosition = rightDoorClosedLocalPosition; // 초기에는 오른쪽 문을 닫힌 상태로 설정
    }

    void MoveDoors()
    {
        leftDoor.localPosition = Vector3.MoveTowards(leftDoor.localPosition, leftDoorTargetLocalPosition, speed * Time.deltaTime);
        rightDoor.localPosition = Vector3.MoveTowards(rightDoor.localPosition, rightDoorTargetLocalPosition, speed * Time.deltaTime);

        // 문이 목표 위치에 도달하면 InvokeRepeating을 중지하여 반복 호출을 취소함
        if (leftDoor.localPosition == leftDoorTargetLocalPosition && rightDoor.localPosition == rightDoorTargetLocalPosition)
        {
            CancelInvoke("MoveDoors");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // 플레이어 태그를 가진 오브젝트가 들어왔을 때
        {
            leftDoorTargetLocalPosition = leftDoorOpenLocalPosition; // 왼쪽 문의 목표 위치를 열린 위치로 설정
            rightDoorTargetLocalPosition = rightDoorOpenLocalPosition; // 오른쪽 문의 목표 위치를 열린 위치로 설정
            InvokeRepeating("MoveDoors", 0, 0.02f); // MoveDoors를 반복 호출
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) // 플레이어 태그를 가진 오브젝트가 나갔을 때
        {
            leftDoorTargetLocalPosition = leftDoorClosedLocalPosition; // 왼쪽 문의 목표 위치를 닫힌 위치로 설정
            rightDoorTargetLocalPosition = rightDoorClosedLocalPosition; // 오른쪽 문의 목표 위치를 닫힌 위치로 설정
            InvokeRepeating("MoveDoors", 0, 0.02f); // MoveDoors를 반복 호출
        }
    }
}

