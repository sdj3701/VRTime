using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class VRJoystickController : MonoBehaviour
{
    public XRController controller; // XR Controller�� �巡�� �� ���
    public GameObject prefab; // ������ �������� �巡�� �� ���
    public float moveSpeed = 1.0f; // �̵� �ӵ� ����

    private void Update()
    {
        if (controller != null && prefab != null)
        {
            var device = controller.inputDevice;

            // ���̽�ƽ �Է� ���� �����ɴϴ�.
            if (device.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 joystickInput))
            {
                // ���̽�ƽ �Է� ���� X�� Y�� ������� �������� �̵��մϴ�.
                Vector3 moveDirection = new Vector3(joystickInput.x, 0, joystickInput.y);
                prefab.transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);
            }
        }
    }
}
