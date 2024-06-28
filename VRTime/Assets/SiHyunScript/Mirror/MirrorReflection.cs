using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class MirrorReflection : MonoBehaviour
{
    public Transform player;
    public Camera mirrorCamera;
    public Transform mirror;

    void LateUpdate()
    {
        // �ſ��� ��� ���� ���� ���
        Vector3 mirrorNormal = mirror.forward;

        // �÷��̾��� ��ġ�� �ſ� ��鿡 ���� �ݻ�
        Vector3 playerToMirror = player.position - mirror.position;
        Vector3 reflectionPosition = player.position - 2 * Vector3.Dot(playerToMirror, mirrorNormal) * mirrorNormal;

        // ī�޶��� ��ġ�� �ݻ�� ��ġ�� ����
        mirrorCamera.transform.position = reflectionPosition;

        // �÷��̾��� ȸ���� �ſ� ��鿡 ���� �ݻ�
        Vector3 reflectionForward = Vector3.Reflect(player.forward, mirrorNormal);
        Vector3 reflectionUp = Vector3.Reflect(player.up, mirrorNormal);

        // ī�޶��� ȸ���� �ݻ�� ȸ������ ����
        mirrorCamera.transform.rotation = Quaternion.LookRotation(reflectionForward, reflectionUp);
    }
}
