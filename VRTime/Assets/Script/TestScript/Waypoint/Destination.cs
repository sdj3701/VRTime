using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destination : MonoBehaviour
{
    public Transform[] WayPoint;
    public IPositionable positionable;

    private void Awake()
    {
        positionable = new Positionable();
        //WayPoint = new

        //위치 데이터에 저장
        for (int i = 0; i < WayPoint.Length; i++)
        {
            positionable.SetWayPointPosition(i, WayPoint[i]);
        }
    }
}
