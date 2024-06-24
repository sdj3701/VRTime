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
        TMP_Text textObject = GetComponentInChildren<TMP_Text>();
        if (textObject != null)
        {
            textObject.text = text;
            Debug.Log("TMP_Text ������Ʈ��: " + textObject.text);
        }
        else
        {
            Debug.LogError("TMP_Text ������Ʈ�� ã�� �� ����.");
        }
        //StartCoroutine(textPrint(delay));
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

    public void ActivatePanel(int _testPanelIndex)
    {
        this.gameObject.SetActive(0 == _testPanelIndex);
    }
}
