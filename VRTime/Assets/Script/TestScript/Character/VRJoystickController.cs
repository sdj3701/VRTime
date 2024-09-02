using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class VRJoystickController : MonoBehaviour
{
    public XRController controller; // XR Controller를 드래그 앤 드롭
    public GameObject prefab; // 움직일 프리팹을 드래그 앤 드롭
    public float moveSpeed = 1.0f; // 이동 속도 조절

    private void Update()
    {
        if (controller != null && prefab != null)
        {
            var device = controller.inputDevice;

            // 조이스틱 입력 값을 가져옵니다.
            if (device.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 joystickInput))
            {
                // 조이스틱 입력 값의 X와 Y를 기반으로 프리팹을 이동합니다.
                Vector3 moveDirection = new Vector3(joystickInput.x, 0, joystickInput.y);
                prefab.transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);
            }
        }
    }
}
