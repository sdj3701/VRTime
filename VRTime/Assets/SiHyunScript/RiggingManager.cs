using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiggingManager : MonoBehaviour
{
    public Transform leftArmIK;
    public Transform rightArmIK;
    public Transform headIK;

    public Transform leftHandController;
    public Transform rightHandController;
    public Transform hmd;

    public Vector3[] leftOffset;
    public Vector3[] rightOffset;
    public Vector3[] headOffset;

    public float smoothValue = 0.1f;
    public float modelHeight = 1.88f;

    private void LateUpdate()
    {
        MappingHandTransform(leftArmIK, leftHandController, true);
        MappingHandTransform(rightArmIK, rightHandController, false);
        MappingBodyTransform(headIK, hmd);
        MappingHeadTransform(headIK, hmd);
    }

    private void MappingHandTransform(Transform ik, Transform controller, bool isLeft)
    {
        // ik�� Transform = controller�� Transform
        var offset = isLeft ? leftOffset : rightOffset;
        ik.position = controller.TransformPoint(offset[0]);
        ik.rotation = controller.rotation * Quaternion.Euler(offset[1]);
    }

    private void MappingBodyTransform(Transform ik, Transform hmd)
    {
        this.transform.position = new Vector3(hmd.position.x, hmd.position.y - modelHeight, ik.position.z);
        float yaw = hmd.eulerAngles.y;
        var targetRotation = new Vector3(this.transform.eulerAngles.x, yaw, this.transform.eulerAngles.z);
        this.transform.rotation = Quaternion.Lerp(this.transform.rotation, Quaternion.Euler(targetRotation), smoothValue);
    }

    private void MappingHeadTransform(Transform ik, Transform hmd)
    {
        ik.position = hmd.TransformPoint(headOffset[0]);
        ik.rotation = hmd.rotation * Quaternion.Euler(headOffset[1]);
    }
}



