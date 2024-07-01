using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour, ICanvasManager
{
    public Canvas canvas;
    public GameObject leftHandModel;
    public GameObject rightHandModel;

    public void SetCanvasToFullScreen(int width, int height)
    {
        if (canvas != null)
        {
            canvas.renderMode = RenderMode.ScreenSpaceCamera;
            canvas.worldCamera = Camera.main;

            CanvasScaler scaler = canvas.GetComponent<CanvasScaler>();
            if (scaler != null)
            {
                scaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
                scaler.referenceResolution = new Vector2(width, height);
            }

            leftHandModel.SetActive(false);
            rightHandModel.SetActive(false);

        }
        else
        {
            Debug.Log("Äµ¹ö½º ¾øÀ½");
        }
    }

    public void SetCanvasToWorldSpace(int width, int height)
    {
        if (canvas != null)
        {
            // Set the render mode to World Space
            canvas.renderMode = RenderMode.WorldSpace;

            // Set the world camera for the canvas
            canvas.worldCamera = Camera.main; // You can assign any camera you want here

            // Update the size and position of the canvas
            RectTransform rectTransform = canvas.GetComponent<RectTransform>();
            rectTransform.sizeDelta = new Vector2(width, height);
            rectTransform.localPosition = new Vector3(0, 0, 1); // Ensure canvas is at the desired position in world space

            // Disable any unnecessary components
            CanvasScaler scaler = canvas.GetComponent<CanvasScaler>();
            if (scaler != null)
            {
                scaler.enabled = false; // Disable CanvasScaler in World Space mode
            }

            // Activate any necessary models or UI elements specific to World Space mode
            leftHandModel.SetActive(true);
            rightHandModel.SetActive(true);

        }
        else
        {
            Debug.Log("Äµ¹ö½º ¾øÀ½");
        }
    }
}
