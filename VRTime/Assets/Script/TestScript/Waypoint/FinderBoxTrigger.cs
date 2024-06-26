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
            // TODO : ���� �����ؾ��ϴ� �ڵ� 2��
            // �̰͵� ����̸� �ȵ�
            videoData.GetVideoDat(0).gameObject.SetActive(true);
            // �� �ȳ� ���Ҽ� ����
            positionable.SetWayCount(1);
        }
    }
}
