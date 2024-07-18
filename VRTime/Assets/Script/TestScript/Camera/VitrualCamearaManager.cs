using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class VitrualCamearaManager : MonoBehaviour
{
    public CinemachineVirtualCamera[] VirtualCamera;

    private void Start()
    {
        FinderBoxTrigger publisher = new FinderBoxTrigger();

        publisher.MyEvent += ChangePriority;
    }

    void ChangePriority(int newPriority)
    {
        Debug.Log("count++ : " + newPriority);
        if (VirtualCamera[newPriority].name == "Virtual Camera" + newPriority)
        {
            VirtualCamera[newPriority].Priority = 10 + newPriority;
        }
    }

    void ResetPriority(int newPriority)
    {
        VirtualCamera[newPriority].Priority = 10;
    }
}
