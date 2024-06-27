using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public interface IPositionable 
{
    public Vector3 GetWayPointPosition(int waypoint);
    public void SetWayPointPosition(int waypoint, GameObject wayPointPosition);
    public void NewMemory(int memoriSize);
    public void SetWayCount(int num);
    public int GetWayCount();
    public void SetCheckPoint(bool check);
    public bool GetCheckPoint();
}
