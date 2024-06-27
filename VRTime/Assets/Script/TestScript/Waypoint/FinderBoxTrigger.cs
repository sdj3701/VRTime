using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinderBoxTrigger : MonoBehaviour
{
    public IPositionable positionable;
    public IVideoData videoData;
    private void Start()
    {
        positionable = new Positionable();
        videoData = new VideoData();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Player")
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
            positionable.SetWayCount(1);
        }
    }
}
