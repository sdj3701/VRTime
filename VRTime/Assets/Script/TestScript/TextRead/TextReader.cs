using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextReader : MonoBehaviour
{
    protected string text;
    //변경할 내용
    public TMP_Text targetText;

    private void Awake()
    {
        text = targetText.text.ToString();
        targetText.text = " ";
    }

}
