using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI.Table;

public class DialogueParse : MonoBehaviour
{
    public ITextData[][] textData = null;
    public IReadTextData readTextData;
    private int textNum = 0;
    public TextAsset[] csvFile = null;

    
    private void Awake()
    {
        //File에 따른 갯수 할당
        textData = new ITextData[csvFile.Length][];

        readTextData = new ReadTextData();
        //인터페이스를 활용한 File 갯수 저장
        readTextData.SetFileCount(csvFile.Length);

        for (textNum = 0; textNum < csvFile.Length; ++textNum)
        {
            Parse(csvFile[textNum].name);
            Debug.Log("-----------------");
        }
    }

    private void Parse(string _CSVFileName)
    {
        TextAsset csvData = Resources.Load<TextAsset>(_CSVFileName);

        string[] data = csvData.text.Split(new char[] { '\n' });
        textData[textNum] = new ITextData[data.Length];
        for (int i = 0 ; i < data.Length ; i++)
        {
            textData[textNum][i] = new TextData();
        }

        // CSV 파일 이름을 최우선으로 넣기위한 작업
        string[] splitdata = _CSVFileName.Split(new char[] { '\n' });
        
        textData[textNum][0].SetDialogueData(splitdata);
        Debug.Log(textNum + " " + textData[textNum][0].GetDialogueData(0, 0));

        for (int i = 1; i < data.Length; i++)   // data[0] = {'ID', '캐릭터 이름', '대사'}
        {
            string[] row = data[i].Split(new char[] { ',' });

            // 인터페이스 활용하여 의존성 약화
            textData[textNum][i].SetDialogueData(row);
            Debug.Log(textNum +" " + i + " " + textData[textNum][i].GetDialogueData(i,0));
        }

        foreach (ITextData textDataItem in textData[textNum])
        {
            ((TextData)textDataItem).Clear();
        }
    }

}
