using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SingleCharPrinter : TextReader
{
    private float delay = 0.125f;

    public void Printer()
    {
        StartCoroutine(textPrint(delay));
    }

    IEnumerator textPrint(float d)
    {
        int count = 0;
        while (count != text.Length)
        {
            if (count < text.Length)
            {
                targetText.text += text[count].ToString();
                count++;
            }
            yield return new WaitForSeconds(delay);
        }
    }
}
