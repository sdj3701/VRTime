using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITextData 
{
    string GetDialogueData(int frist, int second);
    void SetDialogueData(string[] Text);
    int GetTextCount();
    void SetTextCount(int textCount);

}
