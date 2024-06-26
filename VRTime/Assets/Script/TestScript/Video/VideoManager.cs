using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoManager : MonoBehaviour
{
    public GameObject[] videoObject;
    public IVideoData videoData;

    private void Awake()
    {
        videoData = new VideoData();
        videoData.NewMemory(videoObject.Length);

        for (int i = 0; i < videoObject.Length; i++)
        {
            videoData.SetVideoData(i, videoObject[i]);
            videoData.GetVideoDat(i).gameObject.SetActive(false);
        }
    }
}
