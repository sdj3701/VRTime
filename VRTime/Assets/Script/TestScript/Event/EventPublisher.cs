using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventPublisher : MonoBehaviour
{
    // 싱글톤 인스턴스
    private static EventPublisher instance;
    public static EventPublisher Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<EventPublisher>();
                if (instance == null)
                {
                    Debug.LogError("EventPublisher 인스턴스가 존재하지 않습니다.");
                }
            }
            return instance;
        }
    }

    public IPositionable positionable;

    // 이벤트 정의
    public event Action<int> MyEvent;

    void Start()
    {
        positionable = new Positionable();

        // 예시로 위치를 반환하는 positionable을 설정하고 이벤트 발생
        int wayCount = positionable.GetWayCount();
        InvokeEvent(wayCount);
    }
    public void InvokeEvent(int wayCount)
    {
        // 이벤트 호출
        MyEvent?.Invoke(wayCount);
    }
}
