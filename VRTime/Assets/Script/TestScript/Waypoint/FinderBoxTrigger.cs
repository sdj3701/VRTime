using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Events;

public class FinderBoxTrigger : MonoBehaviour
{
    public IPositionable positionable;
    public IVideoData videoData;
    public AudioClip TestaudioClip = null;
    // �̺�Ʈ �׽�Ʈ
    public UnityEvent<int> MyEvent;

    //���߿� �������̽��� ���� �����͵� ��
    public GameObject ChildCamera;
    public GameObject VideoCamera;
    public GameObject otherGameObject;
    public GameObject OtherCamera;
    private GameObject VideoPlayer;

    private void Start()
    {
        positionable = new Positionable();
        videoData = new VideoData();
        VideoPlayer = GameObject.Find("VideoManager");
        ChildCamera = GameObject.Find("Main Camera");
        //VideoCamera = GameObject.Find("MainCamera1");
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        OtherCamera.gameObject.SetActive(true);
        ChildCamera.gameObject.SetActive(false);
        VideoCamera.gameObject.SetActive(true);
        CheckVIdeo checkVIdeo = otherGameObject.GetComponent<CheckVIdeo>();
        AudioListener audioListener = VideoCamera.GetComponent<AudioListener>();
        audioListener.enabled = true;

        if (other.gameObject.name == "Left_Controller" || other.gameObject.name == "Right_Controller" || other.gameObject.name == "Player" && !positionable.GetCheckPoint())
        {
            //���� ��η� ã�Ƽ� �־ ���
            AudioSource audioSource = other.gameObject.GetComponentInChildren<AudioSource>();
            if(audioSource == null)
            {
                Debug.Log("Not Find AudioSource");
                return;
            }    
            AudioClip audioClip = Resources.Load<AudioClip>("Sound/rightnow");
            if (audioClip == null)
            {
                Debug.Log("Not Find AudioClip");
                return;
            }
            audioSource.clip = audioClip;
            audioSource.Play();

            // TODO : ���� �����ؾ��ϴ� �ڵ� 2�� �̰Ÿ� ��Ǿ�� �����ϸ� ���� ����
            // �̰͵� ����̸� �ȵ�
            //videoData.GetVideoData(0).gameObject.SetActive(true);
            // �� �ȳ� ���Ҽ� ����
            positionable.SetCheckPoint(true);
            //Debug.Log("OnTriggerEnter" + positionable.GetCheckPoint());

            if (ChildCamera.activeSelf == true)
            {
                ChildCamera.gameObject.SetActive(false);
                Debug.Log(ChildCamera.name + " false");
            }
            else
            {
                Debug.Log("OnTriggerEnter" + " " + ChildCamera.name + " " + ChildCamera.activeSelf);
            }
            if (VideoCamera.activeSelf == false)
            {
                VideoCamera.gameObject.SetActive(true);
                Debug.Log(VideoCamera.name + " true");
            }
            else
            {
                Debug.Log("OnTriggerEnter" + " " + VideoCamera.name + " " + VideoCamera.activeSelf);
            }
            /*if(positionable.GetCheckPoint())
            {
                // true�� ����ϸ� ��Ȱ��ȭ�� ������Ʈ�� �˻���
                Transform[] allChildren = other.gameObject.GetComponentsInChildren<Transform>(true); 
                
                string targetObjectName1 = "Left Controller";
                string targetObjectName2 = "Right Controller";

                foreach (Transform child in allChildren)
                {
                    if (child.gameObject.name == targetObjectName1)
                        child.gameObject.SetActive(false);

                    if (child.gameObject.name == targetObjectName2)
                    {
                        child.gameObject.SetActive(false);
                        Debug.Log("Hand ������Ʈ�� ��Ȱ��ȭ�߽��ϴ�.");
                        break;
                    }
                }
            }*/

            positionable.SetWayCount(1);
            this.gameObject.SetActive(false);
            checkVIdeo.ScreensSetActive();
            MyEvent.Invoke(positionable.GetWayCount());
            VideoManager video = VideoPlayer.GetComponent<VideoManager>();
            video.VideoLoad();
        }
        else
        {
            Debug.LogWarning(other.name + "���ǿ� ���� ������Ʈ �Դϴ�");
            Debug.LogWarning(positionable.GetCheckPoint());
        }
    }
}
