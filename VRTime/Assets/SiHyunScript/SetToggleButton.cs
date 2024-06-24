using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Rendering;
using UnityEngine;

public class SetToggleButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SetText(string text)
    {
        TMP_Text toggleText = this.GetComponentInChildren<TMP_Text>();
        toggleText.text = text;
    }
}
