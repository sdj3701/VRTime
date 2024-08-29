using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 5f;    // ĳ���� �̵� �ӵ� ���� ����
    public float rotationSpeed = 100f;  // ĳ���� ȸ�� �ӵ� ���� ����

    void Start()
    {
    }

    void Update()
    {
        // WASD �Է��� �޾� ĳ���͸� �̵���ŵ�ϴ�.
        float horizontalInput = Input.GetAxis("Horizontal"); // A, D Ű
        float verticalInput = Input.GetAxis("Vertical"); // W, S Ű

        // ĳ������ ���� ��ǥ�踦 �������� �̵��մϴ�.
        Vector3 moveDirection = new Vector3(horizontalInput, -verticalInput, 0);
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.Self);

        // ���콺 �Է��� �޾� ĳ���͸� Z���� �������� ȸ����ŵ�ϴ�.
        float mouseX = Input.GetAxis("Mouse X");
        transform.Rotate(Vector3.forward, mouseX * rotationSpeed * Time.deltaTime);


    }
}
