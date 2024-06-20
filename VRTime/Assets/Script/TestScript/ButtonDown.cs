using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonDown : MonoBehaviour
{
    private RandomCubeColor randomCubeColor;
    private SingleCharPrinter singleCharPrinter;

    private void Start()
    {
        randomCubeColor = FindObjectOfType<RandomCubeColor>();
        singleCharPrinter = GetComponentInParent<SingleCharPrinter>();
    }

    public void OnClickButtonDown()
    {
        if (randomCubeColor != null)
            randomCubeColor.RandomColor();
        
        if (singleCharPrinter != null)
            singleCharPrinter.Printer();

    }
}
