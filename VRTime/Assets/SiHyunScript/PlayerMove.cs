using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotateSpeed = 100f;

    private CharacterController characterController;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        // 플레이어 이동 처리
        float moveDirectionY = Input.GetAxis("Vertical");
        float moveDirectionX = Input.GetAxis("Horizontal");

        Vector3 move = transform.forward * moveDirectionY + transform.right * moveDirectionX;
        characterController.Move(move * moveSpeed * Time.deltaTime);

        // 마우스 클릭으로 회전 처리
        if (Input.GetMouseButton(0)) // 좌클릭
        {
            transform.Rotate(Vector3.up, -rotateSpeed * Time.deltaTime);
        }
        if (Input.GetMouseButton(1)) // 우클릭
        {
            transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime);
        }
    }
}
