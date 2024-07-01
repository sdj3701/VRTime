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
        //�浹�� �ߴ��� Ȯ��
        if (positionable.GetCheckPoint())
        {
            GameObject videoObject = videoData.GetVideoData(0);
            videoObject.SetActive(true);

            VideoPlayer videoPlayer = videoObject.GetComponent<VideoPlayer>();

            //������ �غ� �Ǿ����� �̺�Ʈ
            videoPlayer.prepareCompleted += VideoPrepared;
            videoPlayer.Prepare();

            if (videoPrepared && videoPlayer.isPlaying)
            {
                Debug.Log("��� ��?");
            }

            // ������ ��� ���� �ƴ� ��� ó��
            if (videoPrepared && !videoPlayer.isPlaying)
            {
                Debug.Log("��� ��");
                // false�̾���� ���� ã��
                positionable.SetCheckPoint(false);

                // ���� �غ� �Ϸ� �̺�Ʈ ����
                videoPlayer.prepareCompleted -= VideoPrepared;

                // ���� ���� ������Ʈ ��Ȱ��ȭ
                videoPlayer.gameObject.SetActive(false);
            }

        }

    }
    private void VideoPrepared(VideoPlayer vp)
    {
        videoPrepared = true;
        vp.Play(); // �غ� �Ϸ� �� ���� ��� ����
    }

}
