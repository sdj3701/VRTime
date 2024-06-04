using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCubeColor : MonoBehaviour
{

    public void RandomColor()
    {
        Renderer cubeRenderer = this.GetComponent<Renderer>();

        Color randomColor = new Color(Random.value, Random.value, Random.value);

        if (cubeRenderer != null)
        {
            cubeRenderer.material.color = randomColor;
        }
        else
        {
            Debug.LogWarning("Cube Object is not Renderer Component");
        }
    }
}
