using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoData : IVideoData
{
    private static GameObject[] videoObject;

    public void SetVideoData(int videoNum, GameObject gameObject)
    {
        videoObject[videoNum] = gameObject;
    }

    public GameObject GetVideoDat(int videoNum)
    {
        return videoObject[videoNum];
    }

    public void NewMemory(int VideoSize)
    {
        videoObject = new GameObject[VideoSize];
    }
}
