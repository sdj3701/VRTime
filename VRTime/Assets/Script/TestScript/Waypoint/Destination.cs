using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destination : MonoBehaviour
{
    public GameObject[] WayPoint;
    public IPositionable positionable;

    private void Awake()
    {
        positionable = new Positionable();
        positionable.NewMemory(WayPoint.Length);
        //위치 데이터에 저장
        for (int i = 0; i < WayPoint.Length; i++)
        {
            positionable.SetWayPointPosition(i, WayPoint[i]);
        }
    }

    private void Start()
    {
        for (int i = 0; i < WayPoint.Length; i++)
        {
            if (i == 0)
                WayPoint[0].SetActive(true);
            else
                WayPoint[i].SetActive(false);
        }
    }

    public void LoadPoint(int Count)
    {
        if (WayPoint.Length == Count)
        {
            Debug.Log("End");
            return;        
        }
        else
        {
            for (int i = 0; i < WayPoint.Length; i++)
            {
                if (i == Count)
                {
                    WayPoint[i].SetActive(true);
                    Debug.Log(i + " " + WayPoint[i]);
                }
                else
                    WayPoint[i].SetActive(false);
            }
        }
        
    }

}
