using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Positionable : IPositionable
{
    public static GameObject[] wayPointPositions;
    public Vector3 GetWayPointPosition(int waypoint)
    {
        Debug.Log(waypoint);
        Debug.Log(wayPointPositions[waypoint]);
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
}
