using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IVideoData 
{

    public void NewMemory(int VideoSize);
    public void SetVideoData(int videoNum, GameObject gameObject);
    public GameObject GetVideoData(int videoNum);
}
