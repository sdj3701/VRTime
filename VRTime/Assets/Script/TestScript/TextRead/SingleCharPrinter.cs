using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;


public class SingleCharPrinter : TextReader
{
    //[SerializeField]
    public float delay;
    public string ReadTextName;
    private int i = 1;

    public void Printer()
    {
        StartCoroutine(textPrint(delay));
    }

    IEnumerator textPrint(float delay)
    {
        // 수정이 필요함
        if (text == ReadTextName)
        {
            //Setting
            text = textData[0].GetDialogueData(2, 2);
        }
        else
        {
            while(text != ReadTextName)
            {
                text = textData[0].GetDialogueData(i, 0);
                i++;
            }
            text = textData[0].GetDialogueData(i, 1);
        }

        StringBuilder builder = new StringBuilder(); // StringBuilder 객체 생성
        int count = 0;

        while (count != text.Length)
        {
            if (count < text.Length)
            {
                builder.Append(text[count]); // 문자열을 StringBuilder에 추가
                targetText.text = builder.ToString(); // 완성된 문자열을 TMP_Text에 할당
                count++;
            }
            yield return new WaitForSeconds(delay);
        }
        
        // TODO : int i가 max 
    }
}
