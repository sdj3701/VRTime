using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    public Transform leftDoor; // ���� �� ������Ʈ�� Transform
    public Transform rightDoor; // ������ �� ������Ʈ�� Transform

    public Vector3 leftDoorOpenLocalPosition; // ���� ���� ������ ���� ���� ��ġ
    public Vector3 leftDoorClosedLocalPosition; // ���� ���� ������ ���� ���� ��ġ
    public Vector3 rightDoorOpenLocalPosition; // ������ ���� ������ ���� ���� ��ġ
    public Vector3 rightDoorClosedLocalPosition; // ������ ���� ������ ���� ���� ��ġ

    public float speed = 2.0f; // ���� �̵��ϴ� �ӵ�

    private Vector3 leftDoorTargetLocalPosition; // ���� ���� ��ǥ ���� ��ġ
    private Vector3 rightDoorTargetLocalPosition; // ������ ���� ��ǥ ���� ��ġ

    void Start()
    {
        leftDoorTargetLocalPosition = leftDoorClosedLocalPosition; // �ʱ⿡�� ���� ���� ���� ���·� ����
        rightDoorTargetLocalPosition = rightDoorClosedLocalPosition; // �ʱ⿡�� ������ ���� ���� ���·� ����
    }

    void MoveDoors()
    {
        leftDoor.localPosition = Vector3.MoveTowards(leftDoor.localPosition, leftDoorTargetLocalPosition, speed * Time.deltaTime);
        rightDoor.localPosition = Vector3.MoveTowards(rightDoor.localPosition, rightDoorTargetLocalPosition, speed * Time.deltaTime);

        // ���� ��ǥ ��ġ�� �����ϸ� InvokeRepeating�� �����Ͽ� �ݺ� ȣ���� �����
        if (leftDoor.localPosition == leftDoorTargetLocalPosition && rightDoor.localPosition == rightDoorTargetLocalPosition)
        {
            CancelInvoke("MoveDoors");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // �÷��̾� �±׸� ���� ������Ʈ�� ������ ��
        {
            leftDoorTargetLocalPosition = leftDoorOpenLocalPosition; // ���� ���� ��ǥ ��ġ�� ���� ��ġ�� ����
            rightDoorTargetLocalPosition = rightDoorOpenLocalPosition; // ������ ���� ��ǥ ��ġ�� ���� ��ġ�� ����
            InvokeRepeating("MoveDoors", 0, 0.02f); // MoveDoors�� �ݺ� ȣ��
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) // �÷��̾� �±׸� ���� ������Ʈ�� ������ ��
        {
            leftDoorTargetLocalPosition = leftDoorClosedLocalPosition; // ���� ���� ��ǥ ��ġ�� ���� ��ġ�� ����
            rightDoorTargetLocalPosition = rightDoorClosedLocalPosition; // ������ ���� ��ǥ ��ġ�� ���� ��ġ�� ����
            InvokeRepeating("MoveDoors", 0, 0.02f); // MoveDoors�� �ݺ� ȣ��
        }
    }
}

