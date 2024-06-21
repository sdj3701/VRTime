using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPanelManager : MonoBehaviour
{
    public GameObject NextButton;
    public GameObject SubmitButton;
    public GameObject[] testPanels;

    private int testPanelIndex = 0;

    void Start()
    {
        AddPanelArray();
        ActivatePanel(testPanelIndex);
    }


    public void OnBeforeButtonClick()
    {
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
        if (testPanelIndex == testPanels.Length - 1)
        {
            NextButton.SetActive(false);
            SubmitButton.SetActive(true);

            testPanels[testPanelIndex].SetActive(false);
            testPanelIndex = (testPanelIndex + 1) % testPanels.Length;
            ActivatePanel(testPanelIndex);
        }
        else if(testPanelIndex < testPanels.Length)
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
        for(int i = 0; i < panelCount-3; i++)
        {
            testPanels[i] = this.transform.GetChild(i+3).gameObject;
        }
    }
}


