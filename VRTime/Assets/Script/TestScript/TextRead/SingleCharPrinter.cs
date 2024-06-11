using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;


public class SingleCharPrinter : MonoBehaviour
{
    protected ITextData textData;
    protected string text;
    //������ ����
    public TMP_Text targetText;

    [SerializeField]
    private float delay = 0.125f;

    private void Start()
    {
        textData = new TextData();
        text = textData.GetDialogueData(0, 2);
        Debug.Log(targetText);
        targetText.text = " ";
    }

    private TMP_Text FindTMPTextInChild(GameObject parentObject)
    {
        TMP_Text tmpText = null;

        // �θ� ������Ʈ�� ��� �ڽ��� ��ȸ�ϸ鼭 TMP_Text�� ã��
        foreach (Transform childTransform in parentObject.transform)
        {
            TMP_Text tmpTextComponent = childTransform.GetComponent<TMP_Text>();
            if (tmpTextComponent != null)
            {
                tmpText = tmpTextComponent;
                break; // TMP_Text�� �߰������� ���� ����
            }
        }

        return tmpText;
    }

    public void Printer(Transform parent)
    {
        StartCoroutine(textPrint(delay, parent));
    }

    IEnumerator textPrint(float delay, Transform parent)
    {
        StringBuilder builder = new StringBuilder(); // StringBuilder ��ü ����
        int count = 0;
        targetText = FindTMPTextInChild(parent.gameObject);
        Debug.Log( delay.ToString() + " " + targetText);
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
