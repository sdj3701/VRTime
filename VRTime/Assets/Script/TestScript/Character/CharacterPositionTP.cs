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
                // 현재 활성화된 IChinemachineCamera를 가져옵니다.
                ICinemachineCamera liveCamera = blendListCamera.LiveChild;

                if (liveCamera != null)
                {
                    // IChinemachineCamera를 CinemachineVirtualCamera로 캐스팅 시도
                    CinemachineVirtualCamera virtualCamera = liveCamera as CinemachineVirtualCamera;

                    if (virtualCamera != null)
                    {
                        Debug.Log("현재 활성화된 가상 카메라: " + virtualCamera.name);
                    }
                    else
                    {
                        Debug.Log("현재 활성화된 카메라는 CinemachineVirtualCamera가 아닙니다.");
                    }
                }
            }
        }
        // 현재 활성화된 가상 카메라를 가져옵니다.
        //CinemachineVirtualCamera activeCamera = cinemachineBrain.ActiveVirtualCamera as CinemachineVirtualCamera;

        /*if (activeCamera != null)
        {
            // 배열에서 활성화된 카메라의 인덱스를 찾습니다.
            int index = System.Array.IndexOf(cameras, activeCamera);

            if (index != -1)
            {
                Debug.Log($"현재 활성화된 카메라는 배열의 {index}번째 카메라입니다: {activeCamera.name}");
            }
            else
            {
                Debug.LogWarning("활성화된 카메라가 배열에 없습니다.");
            }
        }
        else
        {
            Debug.LogError("현재 활성화된 카메라를 찾을 수 없습니다.");
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
    public CanvasGroup uiCanvasGroup; // UI 패널의 CanvasGroup
    public Button switchButton; // 전환 버튼

    private bool isUIVisible = false; // UI 패널의 현재 상태
    private int currentIndex = 0; // 현재 활성화된 카메라의 인덱스

    void Start()
    {
        switchButton.onClick.AddListener(OnSwitchButtonClicked);
        switchButton.gameObject.SetActive(false); // 버튼을 기본적으로 숨김
    }

    void Update()
    {
        // 현재 UI가 보이지 않을 때만 카메라 전환을 시도
        if (!isUIVisible)
        {
            if (Input.GetKeyDown(KeyCode.Space)) // 예를 들어 Space 키를 사용하여 UI를 표시
            {
                ShowUI();
            }
        }
    }

    void ShowUI()
    {
        isUIVisible = true;
        uiCanvasGroup.alpha = 1; // UI 패널을 보이게 설정
        uiCanvasGroup.interactable = true;
        uiCanvasGroup.blocksRaycasts = true;
        switchButton.gameObject.SetActive(true); // 버튼을 보이게 설정
    }

    void HideUI()
    {
        isUIVisible = false;
        uiCanvasGroup.alpha = 0; // UI 패널을 숨김
        uiCanvasGroup.interactable = false;
        uiCanvasGroup.blocksRaycasts = false;
        switchButton.gameObject.SetActive(false); // 버튼을 숨김
    }

    void OnSwitchButtonClicked()
    {
        // 카메라 전환 로직
        currentIndex = (currentIndex + 1) % blendListCamera.m_ChildCameras.Length;
        blendListCamera.m_ChildCameras[currentIndex].m_Priority = 10; // 활성화할 카메라의 우선순위 설정
        for (int i = 0; i < blendListCamera.m_ChildCameras.Length; i++)
        {
            if (i != currentIndex)
            {
                blendListCamera.m_ChildCameras[i].m_Priority = 0; // 비활성화할 카메라의 우선순위 설정
            }
        }

        HideUI(); // UI 숨기기
    }
}
 
 */