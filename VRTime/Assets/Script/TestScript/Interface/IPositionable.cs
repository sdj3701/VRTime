using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPositionable 
{
    public Vector3 GetWayPointPosition(int waypoint);
    public void SetWayPointPosition(int waypoint, GameObject wayPointPosition);
    public void NewMemory(int memoriSize);

}
