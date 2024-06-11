using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonDown : MonoBehaviour
{
    //private bool pressed = false;

    private RandomCubeColor randomCubeColor;
    private SingleCharPrinter singleCharPrinter;
    private Transform parentTransform;

    private void Start()
    {
        randomCubeColor = FindObjectOfType<RandomCubeColor>();
        singleCharPrinter = FindObjectOfType<SingleCharPrinter>();
        parentTransform = transform.parent;
    }

    public void OnClickButtonDown()
    {
        if (randomCubeColor != null)
            randomCubeColor.RandomColor();
        
        if (singleCharPrinter != null)
            singleCharPrinter.Printer(parentTransform);

    }
}
