using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class VitrualCamearaManager : MonoBehaviour
{
    //public CinemachineVirtualCamera[] VirtualCamera; 
    public CinemachineBlendListCamera[] BlendList;

    private void Start()
    {
        var p = FindObjectOfType<FinderBoxTrigger>();
        p.MyEvent.AddListener(ChangePriority);
    }

    public void ChangePriority(int newPriority)
    {
        
        Debug.Log("count++ : " + newPriority);
        //BlendList[newPriority - 1].Priority = 10 + newPriority;
       /* if (VirtualCamera[newPriority].name == "Virtual Camera" + newPriority)
        {
            VirtualCamera[newPriority].Priority = 10 + newPriority;
        }*/
    }

    void ResetPriority(int newPriority)
    {
        //VirtualCamera[newPriority].Priority = 10;
    }
}
