using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadTextData : IReadTextData
{
    private static int fileCount;

    public int GetFileCount()
    {
        return fileCount;
    }
    public void SetFileCount(int fileNumCount)
    {
        fileCount = fileNumCount;
    }

}
