using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadTextData : IReadTextData
{
    private static int fileCount;
    private static int[] fileRow;
    private static int[] fileCol;

    public int GetFileCount()
    {
        return fileCount;
    }
    public void SetFileCount(int fileNumCount)
    {
        fileCount = fileNumCount;
    }

    public int GetFileRowCount(int FileLeght)
    {
        return fileRow[FileLeght];
    }
    public void SetFileRowCount(int FileLeght, int fileColCount)
    {
        fileRow[FileLeght] = fileColCount;
    }
    public void NewMemory(int FileSize)
    {
        fileRow = new int[FileSize + 1];
    }

    public int GetFileColCount(int ColNum)
    {
        return fileCol[ColNum];
    }
    public void SetFileColCount(int FileLeght, int fileColCount)
    {
        fileCol[FileLeght] = fileColCount;
    }

    public void NewColMemory(int FileSize)
    {
        fileCol = new int[FileSize + 1];
    }
}
