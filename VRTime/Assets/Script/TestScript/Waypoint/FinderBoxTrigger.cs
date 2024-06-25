using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinderBoxTrigger : MonoBehaviour
{
    public IPositionable positionable;
    private void Start()
    {
        positionable = new Positionable();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Player")
        {
            positionable.SetWayCount(1);
        }
    }
}
