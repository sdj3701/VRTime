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
        Debug.Log("실행되는중");
        TMP_Text textObject = GetComponentInChildren<TMP_Text>();
        if (textObject != null)
        {
            textObject.text = text;
            Debug.Log("TMP_Text 업데이트됨: " + textObject.text);
        }
        else
        {
            Debug.LogError("TMP_Text 컴포넌트를 찾을 수 없음.");
        }
        //StartCoroutine(textPrint(delay));
    }

    IEnumerator textPrint(float delay)
    {
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

        yield return new WaitForSeconds(1f);

        this.gameObject.SetActive(false);
    }

    public void ActivatePanel(int _testPanelIndex)
    {
        this.gameObject.SetActive(0 == _testPanelIndex);
    }
}
