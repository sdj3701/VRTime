using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerWithDamping : MonoBehaviour
{
    public Transform player; // �÷��̾� ������Ʈ�� Transform
    public Vector3 offset = new Vector3(1.0f, 0, 1.0f); // �÷��̾� ���� ������ ��ġ
    public float smoothTime = 0.3f; // ���� �ð�

    private Vector3 velocity = Vector3.zero; // �ӵ� ����

    void Start()
    {
        // �ʱ� ��ġ ����
        transform.position = player.position + player.TransformDirection(offset);
    }

    void Update()
    {
        // ��ǥ ��ġ ���
        Vector3 targetPosition = player.position + player.TransformDirection(offset);

        // ���踦 ����Ͽ� ���� ������Ʈ ��ġ ������Ʈ
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}


