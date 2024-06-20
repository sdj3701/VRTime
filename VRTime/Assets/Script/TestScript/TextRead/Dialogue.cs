using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] // ����ü�� �ν����� â�� ���̰� �ϱ� ���� �۾�
public struct TalkData
{
    public string name; // ��� ġ�� ĳ���� �̸�
    public string[] contexts; // ��� ����
}

[System.Serializable]
public class Dialogue 
{
    [Tooltip("��� ġ�� ĳ���� �̸�")]
    public string Name;

    [Tooltip("��� ����")]
    public string[] Context;
}
