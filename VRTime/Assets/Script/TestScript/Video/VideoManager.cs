using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoManager : MonoBehaviour
{
    public GameObject[] videoObject;
    public IVideoData videoData;
    public IPositionable positionable;
    private bool videoPrepared = false;

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

    }
    private void Update()
    {
        //충돌을 했는지 확인
        if (positionable.GetCheckPoint())
        {
            GameObject videoObject = videoData.GetVideoData(0);
            videoObject.SetActive(true);

            VideoPlayer videoPlayer = videoObject.GetComponent<VideoPlayer>();

            //영상이 준비 되었는지 이벤트
            videoPlayer.prepareCompleted += VideoPrepared;
            videoPlayer.Prepare();

            if (videoPrepared && videoPlayer.isPlaying)
            {
                Debug.Log("재생 중?");
            }

            // 비디오가 재생 중이 아닌 경우 처리
            if (videoPrepared && !videoPlayer.isPlaying)
            {
                Debug.Log("재생 끝");
                // false이어야지 길을 찾음
                positionable.SetCheckPoint(false);

                // 비디오 준비 완료 이벤트 해제
                videoPlayer.prepareCompleted -= VideoPrepared;

                // 비디오 게임 오브젝트 비활성화
                videoPlayer.gameObject.SetActive(false);
            }

        }

    }
    private void VideoPrepared(VideoPlayer vp)
    {
        videoPrepared = true;
        vp.Play(); // 준비 완료 후 비디오 재생 시작
    }

}
