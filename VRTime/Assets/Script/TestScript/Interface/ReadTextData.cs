using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadTextData : IReadTextData
{
    private static int fileCount;
    private static int[] fileCol;

    public int GetFileCount()
    {
        return fileCount;
    }
    public void SetFileCount(int fileNumCount)
    {
        fileCount = fileNumCount;
    }

    public int GetFileColCount(int FileLeght)
    {
        return fileCol[FileLeght];
    }
    public void SetFileColCount(int FileLeght, int fileColCount)
    {
        fileCol[FileLeght] = fileColCount;
    }
    public void NewMemory(int FileSize)
    {
        fileCol = new int[FileSize + 1];
    }
}
