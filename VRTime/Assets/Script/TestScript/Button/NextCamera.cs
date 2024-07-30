using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextCamera : MonoBehaviour
{
    public CinemachineBlendListCamera BlendListCamera;
    public int TargetIndex = 0;

    private void Start()
    {
        Debug.Log(BlendListCamera.ChildCameras.Length);
    }

    public void SwitchCamera(int index)
    {

    }

    public void OnButtonClick()
    {
        Debug.Log("test");
        if (BlendListCamera != null)
            SwitchCamera(TargetIndex);
    }
}
