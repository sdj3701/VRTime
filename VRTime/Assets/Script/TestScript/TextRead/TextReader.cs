using System.Collections;
using System.Collections.Generic;
using System.Xml;
using TMPro;
using UnityEngine;

public class TextReader : MonoBehaviour
{
    protected ITextData[] textData;
    protected IReadTextData readTextData;
    protected string text;
    //변경할 내용
    public TMP_Text targetText;


    private void Start()
    {
        readTextData = new ReadTextData();
        textData = new ITextData[readTextData.GetFileCount()];
        for (int i = 0; i < readTextData.GetFileCount(); i++)
        {
            textData[i] = new TextData();
            text = textData[i].GetDialogueData(0, 0);
            targetText.text = " ";
        }
    }
}
