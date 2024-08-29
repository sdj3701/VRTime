using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAvatar : MonoBehaviour
{
    public void WearingClothes(string clothesID)
    {
        GameObject targetClothes = this.transform.Find(clothesID).gameObject;
        if (targetClothes != null)
        {
            targetClothes.SetActive(true);
        }
        else
        {
            Debug.Log("ÇØ´ç ¿Ê ¾øÀ½");
        }
    }
}
