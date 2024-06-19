using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IReadTextData 
{
    public int GetFileCount();
    public void SetFileCount(int fileNumCount);

    public int GetFileColCount(int FileLeght);
    public void SetFileColCount(int FileLeght, int fileColCount);

    public void NewMemory(int FileSize);
}
