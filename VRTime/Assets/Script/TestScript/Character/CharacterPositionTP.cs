using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CharacterPositionTP : MonoBehaviour
{
    public ICharacterPosition TPChacterPosition;
    public CinemachineBlendListCamera[] cameras;
    private CinemachineBrain cinemachineBrain;

    private void Start()
    {
        cinemachineBrain = Camera.main.GetComponent<CinemachineBrain>();
        TPChacterPosition = new CharacterPosition();
    }

    private void Update()
    {
        CheckActiveCamera();
    }
    void CheckActiveCamera()
    {
        // ���� Ȱ��ȭ�� ���� ī�޶� �����ɴϴ�.
        //CinemachineVirtualCamera activeCamera = cinemachineBrain.ActiveVirtualCamera as CinemachineVirtualCamera;

        foreach (var blendListCamera in cameras)
        {
            if (blendListCamera != null)
            {
                // ���� Ȱ��ȭ�� IChinemachineCamera�� �����ɴϴ�.
                ICinemachineCamera liveCamera = blendListCamera.LiveChild;

                if (liveCamera != null)
                {
                    // IChinemachineCamera�� CinemachineVirtualCamera�� ĳ���� �õ�
                    CinemachineVirtualCamera virtualCamera = liveCamera as CinemachineVirtualCamera;

                    if (virtualCamera != null)
                    {
                        Debug.Log("���� Ȱ��ȭ�� ���� ī�޶�: " + virtualCamera.name);
                    }
                    else
                    {
                        Debug.Log("���� Ȱ��ȭ�� ī�޶�� CinemachineVirtualCamera�� �ƴմϴ�.");
                    }
                }
            }
        }

        /*if (activeCamera != null)
        {
            // �迭���� Ȱ��ȭ�� ī�޶��� �ε����� ã���ϴ�.
            int index = System.Array.IndexOf(cameras, activeCamera);

            if (index != -1)
            {
                Debug.Log($"���� Ȱ��ȭ�� ī�޶�� �迭�� {index}��° ī�޶��Դϴ�: {activeCamera.name}");
            }
            else
            {
                Debug.LogWarning("Ȱ��ȭ�� ī�޶� �迭�� �����ϴ�.");
            }
        }
        else
        {
            Debug.LogError("���� Ȱ��ȭ�� ī�޶� ã�� �� �����ϴ�.");
        }*/
    }
}
