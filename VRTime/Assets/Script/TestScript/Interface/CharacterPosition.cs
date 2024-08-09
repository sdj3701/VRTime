using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterPosition : ICharacterPosition
{
    public static Transform characterTransform;

    public Transform GetPosition()
    {
        return characterTransform;
    }
    public void SetPosition(Transform position)
    {
        characterTransform = position;
    }
}
