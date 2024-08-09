using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICharacterPosition 
{
    public Transform GetPosition();
    public void SetPosition(Transform position);
}
