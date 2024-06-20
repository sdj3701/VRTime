using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI.Table;

public class DialogueParse : MonoBehaviour
{
    public ITextData textData = null;
    public IReadTextData readTextData;
    private int textNum = 0;
    public TextAsset[] csvFile = null;
    int count = 0;
    int Maxcol;
    int Maxrow;

    private void Awake()
    {
        //File에 따른 갯수 할당
        textData = new TextData();

        // TODO : 인터페이스 크기 배열 크기 먼저 설정해줘야함
        readTextData = new ReadTextData();
        //인터페이스를 활용한 File 갯수 저장
        readTextData.SetFileCount(csvFile.Length);
        readTextData.NewMemory(csvFile.Length);

        DataSize();

        for (textNum = 0; textNum < csvFile.Length; ++textNum)
        {
            Parse(csvFile[textNum].name);
        }
    }

    void DataSize()
    {
        int currentcol;
        int currentrow;
        // TODO : 파일을 전부 다 돌아서 좀 느린듯 여기 최적화
        for (textNum = 0; textNum < csvFile.Length; ++textNum)
        {
            TextAsset csvData = Resources.Load<TextAsset>(csvFile[textNum].name);
            string[] row = csvData.text.Split(new char[] { '\n' });
            currentrow = row.Length;
            for (int i = 1; i < row.Length; i++)
            {
                string[] col = row[i].Split(new char[] { ',' });
                currentcol = col.Length;
                Maxcol = math.max(currentcol, Maxcol);
            }
            Maxrow = math.max(currentrow, Maxrow);
        }
    }

    private void Parse(string _CSVFileName)
    {
        TextAsset csvData = Resources.Load<TextAsset>(_CSVFileName);
        string[] row = csvData.text.Split(new char[] { '\n' });

        readTextData.SetFileColCount(textNum, row.Length);

        // CSV 파일 이름을 최우선으로 넣기위한 작업
        string[] splitdata = _CSVFileName.Split(new char[] { '\n' });

        if (count == 0)
        {
            textData.NewMemory(csvFile.Length, Maxrow, Maxcol);
            count++;
        }

        for (int i = 1; i < row.Length; i++)   // data[0] = {'ID', '캐릭터 이름', '대사'}
        {
            string[] col = row[i].Split(new char[] { ',' });
            // 초기화
            
            // 인터페이스 활용하여 의존성 약화
            for(int j = 0 ; j < col.Length ; j++)
                textData.SetDialogueData(textNum, i, j, col[j]);
        }
        textData.SetDialogueData(textNum, 0, 0, splitdata[0]);
    }
}
