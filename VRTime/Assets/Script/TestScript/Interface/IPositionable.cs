using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPositionable 
{
    public Transform GetWayPointPosition(int waypoint);
    public void SetWayPointPosition(int waypoint, Transform wayPointPosition);

}
