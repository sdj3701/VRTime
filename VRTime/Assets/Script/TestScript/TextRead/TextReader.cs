using System.Collections;
using System.Collections.Generic;
using System.Xml;
using TMPro;
using UnityEngine;

public class TextReader : MonoBehaviour
{
    protected IReadTextData readTextData { get; set; }
    protected string text;
    //변경할 내용
    public TMP_Text targetText;


    private void Start()
    {
        text = readTextData.textData[0].GetDialogueData(0, 0);
        targetText.text = " ";
    }
}
