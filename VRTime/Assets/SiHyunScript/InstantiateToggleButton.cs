using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEditor.UI;
using TMPro;
using System.Text;
using UnityEngine.UI;

public class InstantiateToggleButton : MonoBehaviour
{
    public IReadTextData readTextData;
    public GameObject parant;

    void Start()
    {
        readTextData = new ReadTextData();
        GameObject togglePrafab = Resources.Load<GameObject>("prefabs/Toggle");
        
        string examNumber = this.name.Replace("testPanel", "");
        int num = int.Parse(examNumber);

        if (togglePrafab != null)
        {
            for (int i = 0; i < 5; i++)
            {
                TextData textData = new TextData();
                string dialogueText = textData.GetDialogueData(0, num, 3 + i);
                
                if (dialogueText != null)
                {
                    GameObject toggleObject = Instantiate(togglePrafab, parant.transform);

                    SingleCharPrinter singleCharPrinter = toggleObject.GetComponent<SingleCharPrinter>();
                    
                    if (singleCharPrinter != null)
                    {
                        singleCharPrinter.text = dialogueText;
                        TMP_Text textObject = toggleObject.GetComponentInChildren<TMP_Text>();
                        if (textObject != null)
                        {
                            Debug.Log("SingleCharPrinter �ʱ� �ؽ�Ʈ: " + singleCharPrinter.text);
                            singleCharPrinter.Printer();
                            Debug.Log("Printer ȣ�� �� TMP_Text �ؽ�Ʈ: " + textObject.text);

                            // TMP_Text ���� ������Ʈ�� Ȯ��
                            textObject.text = singleCharPrinter.text;
                            Debug.Log("TMP_Text ���� ������Ʈ��: " + textObject.text);
                        }
                        else
                        {
                            Debug.Log("textObject ����");
                        }
                    }
                }
            }
        }
        else
        {
            Debug.LogError("�������� �ε��� �� �����ϴ�.");
        }
    }
}