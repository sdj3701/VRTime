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
        Debug.Log("����Ǵ���");
        if (targetText != null)
        {
            targetText.text = text;
            Debug.Log("Text : " + text);
            Debug.Log("TMP_Text ������Ʈ��: " + targetText.text);
        }
        else
        {
            Debug.LogError("TMP_Text ������Ʈ�� ã�� �� ����.");
        }
    }

    IEnumerator textPrint(float delay)
    {
        StringBuilder builder = new StringBuilder(); // StringBuilder ��ü ����
        int count = 0;

        while (count != text.Length)
        {
            if (count < text.Length)
            {
                builder.Append(text[count]); // ���ڿ��� StringBuilder�� �߰�
                targetText.text = builder.ToString(); // �ϼ��� ���ڿ��� TMP_Text�� �Ҵ�
                count++;
            }
            yield return new WaitForSeconds(delay);
        }

        yield return new WaitForSeconds(1f);

        this.gameObject.SetActive(false);
    }
}
