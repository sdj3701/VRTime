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


    private void Start()
    {
        positionable = new Positionable();
        videoData = new VideoData();
    }

    private void OnTriggerEnter(Collider other)
    {
        ChildCamera.gameObject.SetActive(false);
        VideoCamera.gameObject.SetActive(true);
        AudioListener audioListener = VideoCamera.GetComponent<AudioListener>();
        audioListener.enabled = true;

        if (other.gameObject.name == "Player" && !positionable.GetCheckPoint())
        {
            
            //���� ��η� ã�Ƽ� �־ ���
            AudioSource audioSource = other.gameObject.GetComponentInChildren<AudioSource>();
            AudioClip audioClip = Resources.Load<AudioClip>("Sound/rightnow");
            audioSource.clip = audioClip;
            audioSource.Play();

            // TODO : ���� �����ؾ��ϴ� �ڵ� 2�� �̰Ÿ� ��Ǿ�� �����ϸ� ���� ����
            // �̰͵� ����̸� �ȵ�
            //videoData.GetVideoData(0).gameObject.SetActive(true);
            // �� �ȳ� ���Ҽ� ����
            positionable.SetCheckPoint(true);
            if(positionable.GetCheckPoint())
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
            }
            
            positionable.SetWayCount(1);
            MyEvent.Invoke(positionable.GetWayCount());
        }
    }
}
