using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 5f;    // 캐릭터 이동 속도 조절 변수
    public float rotationSpeed = 100f;  // 캐릭터 회전 속도 조절 변수

    void Start()
    {
    }

    void Update()
    {
        // WASD 입력을 받아 캐릭터를 이동시킵니다.
        float horizontalInput = Input.GetAxis("Horizontal"); // A, D 키
        float verticalInput = Input.GetAxis("Vertical"); // W, S 키

        // 캐릭터의 로컬 좌표계를 기준으로 이동합니다.
        Vector3 moveDirection = new Vector3(horizontalInput, -verticalInput, 0);
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.Self);

        // 마우스 입력을 받아 캐릭터를 Z축을 기준으로 회전시킵니다.
        float mouseX = Input.GetAxis("Mouse X");
        transform.Rotate(Vector3.forward, mouseX * rotationSpeed * Time.deltaTime);


    }
}
