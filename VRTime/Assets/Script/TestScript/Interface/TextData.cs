using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextData : ITextData
{
    private static int characterCount;
    private static string[][][] DialogueData;

    public string GetDialogueData(int textNum, int first, int second)
    {
        return DialogueData[textNum][first][second];
    }
    public void SetDialogueData(int textNum, int row, int col, string Text)
    {
        DialogueData[textNum][row][col] = Text;
    }

    public int GetTextCount()
    {
        return characterCount;
    }
    public void SetTextCount(int textCount)
    {
        characterCount = textCount;
    }

    public void NewMemory(int textNum, int row, int col)
    {
        DialogueData = new string[textNum + 1][][];

        for (int d = 0; d < textNum; d++)
        {
            DialogueData[d] = new string[row + 1][];

            for (int i = 0; i < row; i++)
            {
                DialogueData[d][i] = new string[col + 1];

                for (int j = 0; j < col; j++)
                {
                    DialogueData[d][i][j] = null;
                }
            }
        }
    }
}