using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventPublisher : MonoBehaviour
{
    // �̱��� �ν��Ͻ�
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
                    Debug.LogError("EventPublisher �ν��Ͻ��� �������� �ʽ��ϴ�.");
                }
            }
            return instance;
        }
    }

    public IPositionable positionable;

    // �̺�Ʈ ����
    public event Action<int> MyEvent;

    void Start()
    {
        positionable = new Positionable();

        // ���÷� ��ġ�� ��ȯ�ϴ� positionable�� �����ϰ� �̺�Ʈ �߻�
        int wayCount = positionable.GetWayCount();
        InvokeEvent(wayCount);
    }
    public void InvokeEvent(int wayCount)
    {
        // �̺�Ʈ ȣ��
        MyEvent?.Invoke(wayCount);
    }
}
