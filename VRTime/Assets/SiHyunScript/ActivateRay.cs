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


    public XRController controller; // ������ XR ��Ʈ�ѷ��� �巡�� �� ���

    // Update is called once per 
    void Update()
    {
        RightTP.SetActive(RightHandIsGrab.action.ReadValue<float>() == 0 && RightActivate.action.ReadValue<float>() > 0.1f);
        LeftTP.SetActive(LeftHandIsGrab.action.ReadValue<float>() == 0 && LeftActivate.action.ReadValue<float>() > 0.1f);
        if (controller != null)
        {
            var device = controller.inputDevice;

            // ���̽�ƽ �Է� ���� �����ɴϴ�.
            if (device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.primary2DAxis, out Vector2 joystickInput))
            {
                // ���̽�ƽ �Է� ���� X�� Y�� �������� ������ �Ǻ��մϴ�.
                if (joystickInput.y > 0.5f) // ����
                {
                    Debug.Log("1"); // ����
                }
                else if (joystickInput.y < -0.5f) // ����
                {
                    Debug.Log("2"); // ����
                }
                else if (joystickInput.x < -0.5f) // ����
                {
                    Debug.Log("3"); // ����
                }
                else if (joystickInput.x > 0.5f) // ������
                {
                    Debug.Log("4"); // ������
                }
            }
        }
    }

}
