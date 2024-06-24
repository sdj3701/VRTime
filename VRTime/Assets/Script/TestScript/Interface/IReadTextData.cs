using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IReadTextData 
{
    public int GetFileCount();
    public void SetFileCount(int fileNumCount);

    public int GetFileRowCount(int FileLeght);
    public void SetFileRowCount(int FileLeght, int fileColCount);

    public int GetFileColCount(int ColNum);
    public void SetFileColCount(int FileLeght, int fileColCount);

    public void NewMemory(int FileSize);

    public void NewColMemory(int FileSize);
}
