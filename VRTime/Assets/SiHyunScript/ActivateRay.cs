using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;

public class ActivateRay : MonoBehaviour
{
    public GameObject RightTP;
    public GameObject LeftTP;
    public InputActionProperty RightActivate;
    public InputActionProperty LeftActivate;
    public InputActionProperty RightHandIsGrab;
    public InputActionProperty LeftHandIsGrab;

    // Update is called once per 
    void Update()
    {
        RightTP.SetActive(RightHandIsGrab.action.ReadValue<float>() == 0 && RightActivate.action.ReadValue<float>() > 0.1f);
        LeftTP.SetActive(LeftHandIsGrab.action.ReadValue<float>() == 0 && LeftActivate.action.ReadValue<float>() > 0.1f);
    }
}
