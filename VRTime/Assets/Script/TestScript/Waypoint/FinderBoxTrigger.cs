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
            //음성 경로로 찾아서 넣어서 재생
            AudioSource audioSource = other.gameObject.GetComponentInChildren<AudioSource>();
            AudioClip audioClip = Resources.Load<AudioClip>("Sound/rightnow");
            audioSource.clip = audioClip;
            audioSource.Play();

            // TODO : 추후 변경해야하는 코드 2줄 이거를 딕션어리로 관리하면 좋을 듯함
            // 이것도 상수이면 안됨
            //videoData.GetVideoData(0).gameObject.SetActive(true);
            // 길 안내 변할수 있음
            positionable.SetCheckPoint(true);
            positionable.SetWayCount(1);
        }
    }
}
