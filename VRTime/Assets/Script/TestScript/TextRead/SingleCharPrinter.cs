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
        if (text == ReadTextName)
        {
            //Setting
            text = readTextData.textData[i].GetDialogueData(2, 2);
        }
        else
        {
            while(text != ReadTextName)
            {
                Debug.Log(text);
                text = readTextData.textData[i].GetDialogueData(i, 0);
                i++;
            }
            text = readTextData.textData[i].GetDialogueData(i, 1);
        }

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
        
        // TODO : int i�� max 
    }
}
