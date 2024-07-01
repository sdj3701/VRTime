using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetFullScreen : MonoBehaviour
{
    private ICanvasManager m_CanvasManager;

    void Start()
    {
        CanvasManager manager = FindObjectOfType<CanvasManager>();
        if (manager != null)
        {
            m_CanvasManager = manager;
        }
        else
        {
            Debug.LogError("CanvasManager not found.");
        }
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.G))
        {
            m_CanvasManager.SetCanvasToFullScreen(2560, 1440);
        }
        if(Input.GetKeyDown(KeyCode.F))
        {
            m_CanvasManager.SetCanvasToFullScreen(1470, 738);
        }
    }
}
