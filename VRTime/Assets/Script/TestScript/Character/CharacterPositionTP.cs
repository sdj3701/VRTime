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
        // 현재 활성화된 가상 카메라를 가져옵니다.
        CinemachineVirtualCamera activeCamera = cinemachineBrain.ActiveVirtualCamera as CinemachineVirtualCamera;

        if (activeCamera != null)
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
        }
    }
}
