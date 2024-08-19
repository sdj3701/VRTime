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
        // ���� Ȱ��ȭ�� ���� ī�޶� �����ɴϴ�.
        //CinemachineVirtualCamera activeCamera = cinemachineBrain.ActiveVirtualCamera as CinemachineVirtualCamera;

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

/*
 * Test Code
 using UnityEngine;
using Cinemachine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
    public CinemachineBlendListCamera blendListCamera;
    public CanvasGroup uiCanvasGroup; // UI �г��� CanvasGroup
    public Button switchButton; // ��ȯ ��ư

    private bool isUIVisible = false; // UI �г��� ���� ����
    private int currentIndex = 0; // ���� Ȱ��ȭ�� ī�޶��� �ε���

    void Start()
    {
        switchButton.onClick.AddListener(OnSwitchButtonClicked);
        switchButton.gameObject.SetActive(false); // ��ư�� �⺻������ ����
    }

    void Update()
    {
        // ���� UI�� ������ ���� ���� ī�޶� ��ȯ�� �õ�
        if (!isUIVisible)
        {
            if (Input.GetKeyDown(KeyCode.Space)) // ���� ��� Space Ű�� ����Ͽ� UI�� ǥ��
            {
                ShowUI();
            }
        }
    }

    void ShowUI()
    {
        isUIVisible = true;
        uiCanvasGroup.alpha = 1; // UI �г��� ���̰� ����
        uiCanvasGroup.interactable = true;
        uiCanvasGroup.blocksRaycasts = true;
        switchButton.gameObject.SetActive(true); // ��ư�� ���̰� ����
    }

    void HideUI()
    {
        isUIVisible = false;
        uiCanvasGroup.alpha = 0; // UI �г��� ����
        uiCanvasGroup.interactable = false;
        uiCanvasGroup.blocksRaycasts = false;
        switchButton.gameObject.SetActive(false); // ��ư�� ����
    }

    void OnSwitchButtonClicked()
    {
        // ī�޶� ��ȯ ����
        currentIndex = (currentIndex + 1) % blendListCamera.m_ChildCameras.Length;
        blendListCamera.m_ChildCameras[currentIndex].m_Priority = 10; // Ȱ��ȭ�� ī�޶��� �켱���� ����
        for (int i = 0; i < blendListCamera.m_ChildCameras.Length; i++)
        {
            if (i != currentIndex)
            {
                blendListCamera.m_ChildCameras[i].m_Priority = 0; // ��Ȱ��ȭ�� ī�޶��� �켱���� ����
            }
        }

        HideUI(); // UI �����
    }
}
 
 */