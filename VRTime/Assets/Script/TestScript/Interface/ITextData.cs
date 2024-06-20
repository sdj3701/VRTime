using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITextData 
{
    string GetDialogueData(int textNum, int frist, int second);
    void SetDialogueData(int textNum, int row, int col, string Text);
    int GetTextCount();
    void SetTextCount(int textCount);

    public void NewMemory(int textNum, int row, int col);
}
