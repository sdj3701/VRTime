using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiggingManager : MonoBehaviour
{
    public Transform leftArmIK;
    public Transform rightArmIK;

    public Transform leftHandController;
    public Transform rightHandController;

    public Vector3[] leftOffset;
    public Vector3[] rightOffset;

    private void LateUpdate()
    {
        MappingHandTransform(leftArmIK, leftHandController, true);
        MappingHandTransform(rightArmIK, rightHandController, false);
    }

    private void MappingHandTransform(Transform ik, Transform controller, bool isLeft)
    {
        // ik¿« Transform = controller¿« Transform
        var offset = isLeft ? leftOffset : rightOffset;
        ik.position = controller.TransformPoint(offset[0]);
        ik.rotation = controller.rotation * Quaternion.Euler(offset[1]);
    }
}



