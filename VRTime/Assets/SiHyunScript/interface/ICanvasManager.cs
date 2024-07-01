using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICanvasManager
{
    void SetCanvasToFullScreen(int width, int height);

    void SetCanvasToWorldSpace(int width, int height);
}
