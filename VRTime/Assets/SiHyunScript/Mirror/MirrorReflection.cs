using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class MirrorReflection : MonoBehaviour
{
    public Transform playerCam;
    public Transform mirrorCam;

    private void Update()
    {
        Vector3 posZ = new Vector3 (this.transform.position.x, playerCam.transform.position.y , this.transform.position.z);
        Vector3 side1 = playerCam.transform.position - posZ;
        Vector3 side2 = this.transform.forward;
        float angle = Vector3.SignedAngle(side1, side2, Vector3.up);

        mirrorCam.localEulerAngles = new Vector3 (0, angle, 0);
    }
}
