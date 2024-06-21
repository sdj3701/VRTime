using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEditor.UI;
using TMPro;
using System.Text;
using UnityEngine.UI;

public class InstantiateEaxmPanel : MonoBehaviour
{
    public IReadTextData readTextData;
    public GameObject parentPanel;

    public GameObject NextButton;
    public GameObject SubmitButton;
    public GameObject[] testPanels;

    private int testPanelIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        readTextData = new ReadTextData();
        GameObject panelPrafab = Resources.Load<GameObject>("prefabs/Test Panel");

        if (panelPrafab != null)
        {
            for (int i = 0; i < readTextData.GetFileCount(); i++)
            {
                // 프리팹 인스턴스화 (생성)
                GameObject examPanel = Instantiate(panelPrafab, parentPanel.transform);
                examPanel.name = "testPanel" + (i + 1);

                TextData textData = new TextData();
                string dialogueText = textData.GetDialogueData(i, 0, 0);

                SingleCharPrinter singleCharPrinter = examPanel.GetComponentInChildren<SingleCharPrinter>();
                if (singleCharPrinter != null)
                {
                    singleCharPrinter.text = dialogueText;
                    TMP_Text textObject = examPanel.GetComponentInChildren<TMP_Text>();
                    if (textObject != null)
                    {
                        textObject.gameObject.SetActive(true);
                        textObject.name = "textObject" + (i + 1);
                        singleCharPrinter.targetText = textObject;
                        textObject.text = dialogueText;

                        Debug.Log(i);
                        Debug.Log(textObject.name + " : " + singleCharPrinter.text);
                        Debug.Log(singleCharPrinter.text);
                    }
                    else
                    {
                        Debug.Log("textObject 없음");
                    }
                }
                else
                {
                    Debug.Log("못 불러옴");
                }
            }
        }
        else
        {
            Debug.LogError("프리팹을 로드할 수 없습니다.");
        }
    }

    public void OnPrintingButton()
    {
        for (int i = 0; i < readTextData.GetFileCount(); i++)
        {
            
        }

        AddPanelArray();
        //ActivatePanel(testPanelIndex);
    }

    public void OnBeforeButtonClick()
    {
        Debug.Log("BeforeButton");
        if (testPanelIndex == testPanels.Length)
        {
            NextButton.SetActive(true);
            SubmitButton.SetActive(false);

            testPanels[testPanelIndex].SetActive(false);
            testPanelIndex = (testPanelIndex - 1 + testPanels.Length) % testPanels.Length;
            ActivatePanel(testPanelIndex);
        }
        else
        {
            testPanels[testPanelIndex].SetActive(false);
            testPanelIndex = (testPanelIndex - 1 + testPanels.Length) % testPanels.Length;
            ActivatePanel(testPanelIndex);
        }
    }

    public void OnNextButtonClick()
    {
        Debug.Log("NextButton");
        if (testPanelIndex == testPanels.Length - 1)
        {
            NextButton.SetActive(false);
            SubmitButton.SetActive(true);

            testPanels[testPanelIndex].SetActive(false);
            testPanelIndex = (testPanelIndex + 1) % testPanels.Length;
            ActivatePanel(testPanelIndex);
        }
        else if (testPanelIndex < testPanels.Length)
        {
            testPanels[testPanelIndex].SetActive(false);
            testPanelIndex = (testPanelIndex + 1) % testPanels.Length;
            ActivatePanel(testPanelIndex);
        }
    }

    public void OnSubmitButtonClick()
    {

    }

    public void ActivatePanel(int _testPanelIndex)
    {
        for (int i = 0; i < testPanels.Length; i++)
        {
            testPanels[i].SetActive(i == _testPanelIndex);
        }
    }
    public void AddPanelArray()
    {
        int panelCount = this.transform.childCount;
        testPanels = new GameObject[panelCount - 3];
        for (int i = 0; i < panelCount - 3; i++)
        {
            testPanels[i] = this.transform.GetChild(i + 3).gameObject;
        }
    }
}
