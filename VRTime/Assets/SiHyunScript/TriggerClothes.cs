using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerClothes : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("콜라이더 충돌");
        Debug.Log(other.name);
        if(this.CompareTag("suit"))
        {
            Debug.Log("슈트와 충돌");
            CharacterAvatar characterAvatar = other.GetComponentInParent<CharacterAvatar>();
            characterAvatar.WearingClothes("suit");
        }
        else if(this.CompareTag("mask"))
        {
            CharacterAvatar characterAvatar = other.GetComponentInParent<CharacterAvatar>();
            characterAvatar.WearingClothes("mask");
        }
        else if (this.CompareTag("shoes"))
        {
            CharacterAvatar characterAvatar = other.GetComponentInParent<CharacterAvatar>();
            characterAvatar.WearingClothes("shoes");
        }
        else if (this.CompareTag("glove"))
        {
            CharacterAvatar characterAvatar = other.GetComponentInParent<CharacterAvatar>();
            characterAvatar.WearingClothes("glove");
        }
        else if (this.CompareTag("haircap"))
        {
            CharacterAvatar characterAvatar = other.GetComponentInParent<CharacterAvatar>();
            characterAvatar.WearingClothes("haircap");
        }
    }
}
