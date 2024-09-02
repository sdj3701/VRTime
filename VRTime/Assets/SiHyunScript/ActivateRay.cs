using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;
using UnityEngine.XR;

public class ActivateRay : MonoBehaviour
{
    public GameObject RightTP;
    public GameObject LeftTP;
    public InputActionProperty RightActivate;
    public InputActionProperty LeftActivate;
    public InputActionProperty RightHandIsGrab;
    public InputActionProperty LeftHandIsGrab;


    public XRController controller; // 연결할 XR 컨트롤러를 드래그 앤 드롭

    // Update is called once per 
    void Update()
    {
        RightTP.SetActive(RightHandIsGrab.action.ReadValue<float>() == 0 && RightActivate.action.ReadValue<float>() > 0.1f);
        LeftTP.SetActive(LeftHandIsGrab.action.ReadValue<float>() == 0 && LeftActivate.action.ReadValue<float>() > 0.1f);
        if (controller != null)
        {
            var device = controller.inputDevice;

            // 조이스틱 입력 값을 가져옵니다.
            if (device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.primary2DAxis, out Vector2 joystickInput))
            {
                // 조이스틱 입력 값의 X와 Y를 기준으로 방향을 판별합니다.
                if (joystickInput.y > 0.5f) // 앞쪽
                {
                    Debug.Log("1"); // 앞쪽
                }
                else if (joystickInput.y < -0.5f) // 뒤쪽
                {
                    Debug.Log("2"); // 뒤쪽
                }
                else if (joystickInput.x < -0.5f) // 왼쪽
                {
                    Debug.Log("3"); // 왼쪽
                }
                else if (joystickInput.x > 0.5f) // 오른쪽
                {
                    Debug.Log("4"); // 오른쪽
                }
            }
        }
    }

}
