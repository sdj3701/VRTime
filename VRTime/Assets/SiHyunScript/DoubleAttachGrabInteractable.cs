using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DoubleAttachGrabInteractable : XRGrabInteractable
{
    public Transform LeftAttachTransform;
    public Transform RightAttachTransform; 

    private void Start()
    {
        
    }

    protected override void OnHoverEntered(XRBaseInteractor interactor)
    {
        if (interactor.CompareTag("Left Controller"))
        {
            this.attachTransform = LeftAttachTransform;
            Debug.Log("Left");
        }
        else if (interactor.CompareTag("Right Controller"))
        {
            this.attachTransform = RightAttachTransform;
            Debug.Log("Right");
        }
    }

    protected override void OnHoverExited(XRBaseInteractor interactor)
    {
        this.attachTransform = null;
    }

    protected override void OnSelectEntered(XRBaseInteractor interactor)
    {

    }

    protected override void OnSelectExited(XRBaseInteractor interactor)
    {
    }

    protected override void OnActivate(XRBaseInteractor interactor)
    {
    }
}
