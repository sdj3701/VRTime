using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerWithLerp : MonoBehaviour
{
    public Transform player;
    public Vector3 offset = new Vector3(1.0f, 0, 1.0f);
    public float followSpeed = 2.0f;

    private Vector3 targetPosition;

    void Start()
    {
        targetPosition = player.position + offset;    
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 desiredPosition = player.position + player.TransformDirection(offset);
        targetPosition = Vector3.Lerp(targetPosition, desiredPosition, followSpeed * Time.deltaTime);
        transform.position = targetPosition;
    }
}
