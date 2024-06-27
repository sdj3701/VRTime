using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoManager : MonoBehaviour
{
    public GameObject[] videoObject;
    public IVideoData videoData;
    public IPositionable positionable;
    VideoPlayer videoPlayer;
    int count = 0;

    private void Awake()
    {
        videoData = new VideoData();
        positionable = new Positionable();
        videoData.NewMemory(videoObject.Length);

        for (int i = 0; i < videoObject.Length; i++)
        {
            videoData.SetVideoData(i, videoObject[i]);
            videoData.GetVideoData(i).gameObject.SetActive(false);
        }
        videoPlayer = videoData.GetVideoData(0).GetComponent<VideoPlayer>();

    }

    private void FixedUpdate()
    {
        if(positionable.GetCheckPoint())
        {
            videoData.GetVideoData(0).gameObject.SetActive(true);
            if (count == 0)
            {
                videoPlayer.Play();
                count++;
            }

            if (videoPlayer.isPlaying)
            {
                Debug.Log("재생 중?");
            }
            else
            {
                Debug.Log("재생 끝");
                //false이어야지 길을 찾음
                positionable.SetCheckPoint(false);
            }
            
        }
    }
}
