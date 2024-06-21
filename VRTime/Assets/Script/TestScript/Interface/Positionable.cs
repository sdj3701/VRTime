using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Positionable : IPositionable
{
    private Transform[] wayPointPositions;
    public Transform GetWayPointPosition(int waypoint)
    {
        return wayPointPositions[waypoint];
    }
    public void SetWayPointPosition(int waypoint, Transform wayPointPosition)
    {
        wayPointPositions[waypoint] = wayPointPosition;
    }
    public void NewMemory(int memoriSize)
    {
        wayPointPositions = new Transform[memoriSize];
    }
}
