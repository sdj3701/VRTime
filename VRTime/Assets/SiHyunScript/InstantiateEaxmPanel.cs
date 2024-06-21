using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEditor.UI;
using TMPro;

public class InstantiateEaxmPanel : MonoBehaviour
{
    public IReadTextData readTextData;
    public GameObject parentPanel;

    private SingleCharPrinter singleCharPrinter;

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
                GameObject examPanel = Instantiate(panelPrafab);
                // 인스턴스의 부모를 parentPanel로 설정
                examPanel.transform.SetParent(parentPanel.transform, false);

                singleCharPrinter = examPanel.GetComponentInChildren<SingleCharPrinter>();
                if (singleCharPrinter != null)
                {
                    singleCharPrinter.Printer();
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

        AddPanelArray();
        ActivatePanel(testPanelIndex);
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
