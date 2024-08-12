using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerClothes : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("suit"))
        {
            CharacterAvatar characterAvatar = other.GetComponentInParent<CharacterAvatar>();
            characterAvatar.WearingClothes("suit");
        }
        else if(other.CompareTag("mask"))
        {
            CharacterAvatar characterAvatar = other.GetComponentInParent<CharacterAvatar>();
            characterAvatar.WearingClothes("mask");
        }
        else if (other.CompareTag("shoes"))
        {
            CharacterAvatar characterAvatar = other.GetComponentInParent<CharacterAvatar>();
            characterAvatar.WearingClothes("shoes");
        }
        else if (other.CompareTag("glove"))
        {
            CharacterAvatar characterAvatar = other.GetComponentInParent<CharacterAvatar>();
            characterAvatar.WearingClothes("glove");
        }
        else if (other.CompareTag("haircap"))
        {
            CharacterAvatar characterAvatar = other.GetComponentInParent<CharacterAvatar>();
            characterAvatar.WearingClothes("haircap");
        }
    }
}
