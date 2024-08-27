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
    public GameObject ChildCamera;
    public GameObject VideoCamera;
    public GameObject OtherCamera;
    public GameObject ExamTest;

    VideoPlayer videoPlayer;

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

    private void LateUpdate()
    {
        //�浹�� �ߴ��� Ȯ��
        if (positionable.GetCheckPoint())
        {
            // Fix 
            /*GameObject videoObject = videoData.GetVideoData(positionable.GetWayCount() - 1);
            videoObject.SetActive(true);
            Debug.Log(videoObject.name);
            // ���ڵ� �����ϼ��� �ִ� ���� �����ε� ã�ƺ��� �ٷ� ��� ���� �ع����� ������ �־���
            VideoPlayer videoPlayer = videoObject.GetComponent<VideoPlayer>();
            if(videoPlayer != null )
            {
                //������ �غ� �Ǿ����� �̺�Ʈ
                Debug.Log("videoPlayer Not Null");
                videoPlayer.prepareCompleted += VideoPrepared;
                videoPlayer.Prepare();
            }*/
            

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
                ChildCamera.gameObject.SetActive(true);
                VideoCamera.gameObject.SetActive(false);
                OtherCamera.gameObject.SetActive(false);
                Debug.Log(ChildCamera.name + " "+ ChildCamera.activeSelf);
                Debug.Log(VideoCamera.name + " "+ VideoCamera.activeSelf);

                /*if(!positionable.GetCheckPoint())
                {
                    GameObject test = GameObject.Find("Main Camera1");
                    // true�� ����ϸ� ��Ȱ��ȭ�� ������Ʈ�� �˻���
                    Transform[] allChildren = test.gameObject.GetComponentsInChildren<Transform>(true);

                    string targetObjectName1 = "Left Controller";
                    string targetObjectName2 = "Right Controller";

                    foreach (Transform child in allChildren)
                    {
                        if (child.gameObject.name == targetObjectName1)
                            child.gameObject.SetActive(true);

                        if (child.gameObject.name == targetObjectName2)
                        {
                            child.gameObject.SetActive(true);
                            break;
                        }
                    }
                }*/

                // ���� �غ� �Ϸ� �̺�Ʈ ����
                videoPlayer.prepareCompleted -= VideoPrepared;
                videoPrepared = false;
                // ���� ���� ������Ʈ ��Ȱ��ȭ
                videoPlayer.gameObject.SetActive(false);
                if(positionable.GetWayCount() - 1 == 2)
                {
                    Debug.Log("Exam Test OK!!!!!!!!!!!!!!!!!!!!!!!");
                    ExamTest.gameObject.SetActive(true);
                }
            }

        }

    }
    private void VideoPrepared(VideoPlayer vp)
    {
        videoPrepared = true;
        vp.Play(); // �غ� �Ϸ� �� ���� ��� ����
        Debug.Log("video Play Start");
    }

    public void VideoLoad()
    {
        if (positionable.GetCheckPoint())
        {
            // Fix 
            GameObject videoObject = videoData.GetVideoData(positionable.GetWayCount() - 1);
            videoObject.SetActive(true);
            Debug.Log(videoObject.name);
            // ���ڵ� �����ϼ��� �ִ� ���� �����ε� ã�ƺ��� �ٷ� ��� ���� �ع����� ������ �־���
            videoPlayer = videoObject.GetComponent<VideoPlayer>();
            if (videoPlayer != null)
            {
                //������ �غ� �Ǿ����� �̺�Ʈ
                Debug.Log("videoPlayer Not Null");
                videoPlayer.prepareCompleted += VideoPrepared;
                videoPlayer.Prepare();
            }
        }
    }
}
