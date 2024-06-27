using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEditor.UI;
using TMPro;
using System.Text;
using UnityEngine.UI;
using System.Linq;
using static UnityEngine.Rendering.DebugUI;

public class InstantiateEaxmPanel : MonoBehaviour
{
    public IReadTextData readTextData;
    public GameObject parentPanel;

    public GameObject BeforeButton;
    public GameObject NextButton;
    public GameObject SubmitButton;
    public GameObject[] testPanels;

    private int testPanelIndex = 0;

    private List<int> selectList;
    private List<int> answerList;

    public GameObject ScorePanel;
    public TMP_Text IncorrecCount;
    public TMP_Text AnswerCount;
    public TMP_Text Score;

    // Start is called before the first frame update
    void Start()
    {
        readTextData = new ReadTextData();
        GameObject panelPrafab = Resources.Load<GameObject>("prefabs/Test Panel");

        if (panelPrafab != null)
        {
            for (int i = 1; i < readTextData.GetFileRowCount(0); i++)
            {
                // 프리팹 인스턴스화 (생성)
                GameObject examPanel = Instantiate(panelPrafab, parentPanel.transform);
                examPanel.name = "testPanel" + (i);

                TextData textData = new TextData();
                string dialogueText = textData.GetDialogueData(0, i, 1);

                SingleCharPrinter singleCharPrinter = examPanel.GetComponentInChildren<SingleCharPrinter>();

                if (singleCharPrinter != null)
                {
                    singleCharPrinter.text = dialogueText;
                    TMP_Text textObject = examPanel.GetComponentInChildren<TMP_Text>();
                    if (textObject != null)
                    {
                        singleCharPrinter.targetText = textObject;
                        singleCharPrinter.Printer();
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

        AddPanelArray();
        ActivatePanel(testPanelIndex);
        SetAnswerList();
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

    public void ActivatePanel(int _testPanelIndex)
    {
        for (int i = 0; i < testPanels.Length; i++)
        {
            testPanels[i].SetActive(i == _testPanelIndex);
        }
    }

    public void OnBeforeButtonClick()
    {
        // 현재 testPanel을 비활성화하고 이전 testPanel을 활성화
        testPanels[testPanelIndex].SetActive(false);
        testPanelIndex = (testPanelIndex - 1 + testPanels.Length) % testPanels.Length;
        ActivatePanel(testPanelIndex);

        // NextButton과 SubmitButton 상태 설정
        NextButton.SetActive(true);
        SubmitButton.SetActive(false);

        // 이전 버튼이 첫 번째 패널이면 비활성화
        if (testPanelIndex == 0)
        {
            BeforeButton.SetActive(false);
        }
        else
        {
            BeforeButton.SetActive(true);
        }
    }

    public void OnNextButtonClick()
    {
        // 현재 testPanel을 비활성화하고 다음 testPanel을 활성화
        testPanels[testPanelIndex].SetActive(false);
        testPanelIndex = (testPanelIndex + 1) % testPanels.Length;
        ActivatePanel(testPanelIndex);

        // NextButton과 SubmitButton 상태 설정
        if (testPanelIndex == testPanels.Length - 1)
        {
            NextButton.SetActive(false);
            SubmitButton.SetActive(true);
        }
        else
        {
            NextButton.SetActive(true);
            SubmitButton.SetActive(false);
        }

        // 첫 번째 패널이 아니면 '이전' 버튼 활성화
        if (testPanelIndex != 0)
        {
            BeforeButton.SetActive(true);
        }
    }

    public void OnSubmitButtonClick()
    {
        SetSelectList();
        CompareAnswers();
        parentPanel.SetActive(false);
        ScorePanel.SetActive(true);
    }

    public void SetAnswerList()
    {
        answerList = new List<int>();

        for (int i = 0; i < testPanels.Length; i++)
        {
            TextData textData = new TextData();
            string answer = textData.GetDialogueData(0, i + 1, 2);
            int answerNum = int.Parse(answer);
            answerList.Add(answerNum);
        }
    }

    public void SetSelectList()
    {
        selectList = new List<int>();

        foreach (var panel in testPanels)
        {
            ToggleGroup toggleGroup = panel.GetComponentInChildren<ToggleGroup>();
            if (toggleGroup != null)
            {
                List<Toggle> toggles = toggleGroup.GetComponentsInChildren<Toggle>().ToList();
                for (int i = 0; i < toggles.Count; i++)
                {
                    if (toggles[i].isOn)
                    {
                        selectList.Add(i + 1);
                        break;
                    }
                }
            }
        }
    }

    public void CompareAnswers()
    {
        List<int> incorrectList = new List<int>();
        int answerCount = 0;
        int score = 0;

        if (answerList.Count != selectList.Count)
        {
            Debug.LogError("정답과 선택지 개수가 맞지 않음.");
            return;
        }
        
        for(int i = 0; i < answerList.Count;i++)
        {
            if (answerList[i] == selectList[i])
            {
                answerCount++;
            }
            else if (answerList[i] != selectList[i])
            {
                incorrectList.Add(i);
            }
        }

        string resultTextString = "";

        if (incorrectList.Count > 0)
        {
            resultTextString += "틀린 문제 번호 : ";
            for (int i = 0; i < incorrectList.Count; i++)
            {
                resultTextString += (incorrectList[i] + 1);
                if (i < incorrectList.Count - 1)
                {
                    resultTextString += ", ";
                }
            }
        }
        else
        {
            Debug.Log("모든 문제를 맞추셨습니다!");
        }

        // 점수 계산 및 출력
        score = (int)(((float)answerCount / answerList.Count) * 100); // 점수 계산
        IncorrecCount.text = resultTextString;
        AnswerCount.text = "맞춘 문제 수: " + answerCount + " / " + answerList.Count;
        Score.text = "점수: " + score + " / 100";
    }
}
