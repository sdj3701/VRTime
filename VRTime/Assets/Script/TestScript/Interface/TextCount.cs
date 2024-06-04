using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextCount : ITextCount
{
    private static int characterCount;

    public int GetTextCount()
    {
        return characterCount;
    }

    public void SetTextCount(int count)
    {
        characterCount = count; 
    }
}
