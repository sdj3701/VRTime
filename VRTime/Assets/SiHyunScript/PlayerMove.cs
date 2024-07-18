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
        // �÷��̾� �̵� ó��
        float moveDirectionY = Input.GetAxis("Vertical");
        float moveDirectionX = Input.GetAxis("Horizontal");

        Vector3 move = transform.forward * moveDirectionY + transform.right * moveDirectionX;
        characterController.Move(move * moveSpeed * Time.deltaTime);

        // ���콺 Ŭ������ ȸ�� ó��
        if (Input.GetMouseButton(0)) // ��Ŭ��
        {
            transform.Rotate(Vector3.up, -rotateSpeed * Time.deltaTime);
        }
        if (Input.GetMouseButton(1)) // ��Ŭ��
        {
            transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime);
        }
    }
}
