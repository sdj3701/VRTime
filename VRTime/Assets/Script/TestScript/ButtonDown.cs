using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonDown : MonoBehaviour
{
    bool pressed = false;

    public RandomCubeColor randomCubeColor;
    public SingleCharPrinter singleCharPrinter;

    private void Start()
    {
        randomCubeColor = FindObjectOfType<RandomCubeColor>();
        singleCharPrinter = FindObjectOfType<SingleCharPrinter>();
    }

    public void OnClickButtonDown()
    {
        if (randomCubeColor != null)
            randomCubeColor.RandomColor();
        
        
        if (singleCharPrinter != null)
            singleCharPrinter.Printer();

    }
}
