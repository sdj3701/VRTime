using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;


public class SingleCharPrinter : MonoBehaviour
{
    protected ITextData textData;
    protected string text;
    //변경할 내용
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

        // 부모 오브젝트의 모든 자식을 순회하면서 TMP_Text를 찾음
        foreach (Transform childTransform in parentObject.transform)
        {
            TMP_Text tmpTextComponent = childTransform.GetComponent<TMP_Text>();
            if (tmpTextComponent != null)
            {
                tmpText = tmpTextComponent;
                break; // TMP_Text를 발견했으면 루프 종료
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
        StringBuilder builder = new StringBuilder(); // StringBuilder 객체 생성
        int count = 0;
        targetText = FindTMPTextInChild(parent.gameObject);
        Debug.Log( delay.ToString() + " " + targetText);
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
