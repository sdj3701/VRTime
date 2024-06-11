using System.Collections;
using System.Collections.Generic;
using System.Xml;
using TMPro;
using UnityEngine;

public class TextReader : MonoBehaviour
{
    protected ITextData textData;
    protected string text;
    //변경할 내용
    public TMP_Text targetText;


    private void Start()
    {
        textData = new TextData();
        text = textData.GetDialogueData(0, 2);
        targetText.text = " ";
    }
}
