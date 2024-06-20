using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;


public class SingleCharPrinter : TextReader
{
    public float delay;
    private int i = 1;

    public void Printer()
    {
        StartCoroutine(textPrint(delay));
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
    }
}
