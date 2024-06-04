using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonDown : MonoBehaviour
{
    bool pressed = false;

    public RandomCubeColor randomCubeColor;

    private void Start()
    {
        randomCubeColor = FindObjectOfType<RandomCubeColor>();
    }

    public void OnClickButtonDown()
    {
        Debug.Log("Down");
        Debug.Log(randomCubeColor);
        if (randomCubeColor != null)
        {
            Debug.Log("check");
            randomCubeColor.RandomColor();
        }
    }
}
