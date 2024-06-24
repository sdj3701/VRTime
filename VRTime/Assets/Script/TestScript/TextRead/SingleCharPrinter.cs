using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;


public class SingleCharPrinter : TextReader
{
    public float delay;

    public void Printer()
    {
        StartCoroutine(textPrint(delay));
    }

    IEnumerator textPrint(float delay)
    {
        StringBuilder builder = new StringBuilder(); // StringBuilder 객체 생성
        int count = 0;

        yield return new WaitForSeconds(0.5f);

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
    }
}
