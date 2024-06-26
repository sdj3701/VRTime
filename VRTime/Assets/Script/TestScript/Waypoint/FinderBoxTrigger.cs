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
            // TODO : 추후 변경해야하는 코드 2줄
            // 이것도 상수이면 안됨
            videoData.GetVideoDat(0).gameObject.SetActive(true);
            // 길 안내 변할수 있음
            positionable.SetWayCount(1);
        }
    }
}
