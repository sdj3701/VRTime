using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckVIdeo : MonoBehaviour
{
    public IPositionable positionable;
    public GameObject[] videoScreens;
    public GameObject parentObject;

    public void Awake()
    {
        positionable = new Positionable();
    }

    public void ScreensSetActive()
    {
        if (positionable == null)
        {
            positionable = new Positionable();
        }

        Debug.Log(positionable.GetWayCount());

        for (int i = 0; i<videoScreens.Length; i++)
        {
            if(positionable.GetWayCount() - 1 == i )
                videoScreens[i].gameObject.SetActive(true);
            else
                videoScreens[i].gameObject.SetActive(false);
        }
    }
}
