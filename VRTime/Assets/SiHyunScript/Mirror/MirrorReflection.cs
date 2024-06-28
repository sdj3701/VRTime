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
        // 거울의 평면 법선 벡터 계산
        Vector3 mirrorNormal = mirror.forward;

        // 플레이어의 위치를 거울 평면에 대해 반사
        Vector3 playerToMirror = player.position - mirror.position;
        Vector3 reflectionPosition = player.position - 2 * Vector3.Dot(playerToMirror, mirrorNormal) * mirrorNormal;

        // 카메라의 위치를 반사된 위치로 설정
        mirrorCamera.transform.position = reflectionPosition;

        // 플레이어의 회전을 거울 평면에 대해 반사
        Vector3 reflectionForward = Vector3.Reflect(player.forward, mirrorNormal);
        Vector3 reflectionUp = Vector3.Reflect(player.up, mirrorNormal);

        // 카메라의 회전을 반사된 회전으로 설정
        mirrorCamera.transform.rotation = Quaternion.LookRotation(reflectionForward, reflectionUp);
    }
}
