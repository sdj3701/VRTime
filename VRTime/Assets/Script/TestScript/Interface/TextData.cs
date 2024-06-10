using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextData : ITextData
{
    private static List<string[]> dialogueDataList = new List<string[]>();
    private static int CharacterCount;

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
        return CharacterCount;
    }
    public void SetTextCount(int textCount)
    {
        CharacterCount = textCount;
    }
}