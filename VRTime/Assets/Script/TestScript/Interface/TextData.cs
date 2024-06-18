using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextData : ITextData
{
    private static List<string[]> dialogueDataList = new List<string[]>();
    private static int characterCount;

    public string GetDialogueData(int first, int second)
    {
        string[][] DialogueData = dialogueDataList.ToArray();
        return DialogueData[first][second];
    }
    public void SetDialogueData(string[] Text)
    {
        dialogueDataList.Add(Text);
    }

    public int GetTextCount()
    {
        return characterCount;
    }
    public void SetTextCount(int textCount)
    {
        characterCount = textCount;
    }

    public void Clear()
    {
        dialogueDataList.Clear();   
    }
}