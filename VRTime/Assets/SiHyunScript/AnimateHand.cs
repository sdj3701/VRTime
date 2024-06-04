using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;
using UnityEngine.InputSystem;

public class AnimateHand : MonoBehaviour
{
    public InputActionProperty pinchAnimationAction;
    public InputActionProperty gripAnimationAction;
    public Animator handAnimator;
    void Start()
    {
        
    }

    void Update()
    {
        float triggerValue = pinchAnimationAction.action.ReadValue<float>(); //트리거이기 떄문에 값이 float, 버튼일 경우 bool.
        handAnimator.SetFloat("Trigger",triggerValue);

        float gripValue = gripAnimationAction.action.ReadValue<float>();
        handAnimator.SetFloat("Grip", gripValue);
    }
}
