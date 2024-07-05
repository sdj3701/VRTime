using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Positionable : IPositionable
{
    public static GameObject[] wayPointPositions;
    public static int wayPointCount = 0;
    public static bool FindPoint = false;
    public Vector3 GetWayPointPosition(int waypoint)
    {
        return wayPointPositions[waypoint].transform.position;
    }
    public void SetWayPointPosition(int waypoint, GameObject wayPointPosition)
    {
        wayPointPositions[waypoint] = wayPointPosition;
    }
    public void NewMemory(int memoriSize)
    {
        wayPointPositions = new GameObject[memoriSize];
        for (int i = 0; i < memoriSize; i++)
        {
            wayPointPositions[i] = null;
        }
    }
    public void SetWayCount(int num)
    {
        wayPointCount += num;
    }
    public int GetWayCount()
    {
        return wayPointCount;
    }
    public void SetCheckPoint(bool check)
    {
        FindPoint = check;
    }
    public bool GetCheckPoint()
    {
        return FindPoint;
    }
}
