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
        //File�� ���� ���� �Ҵ�
        textData = new TextData();

        // TODO : �������̽� ũ�� �迭 ũ�� ���� �����������
        readTextData = new ReadTextData();
        //�������̽��� Ȱ���� File ���� ����
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
        // TODO : ������ ���� �� ���Ƽ� �� ������ ���� ����ȭ
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

        // CSV ���� �̸��� �ֿ켱���� �ֱ����� �۾�
        string[] splitdata = _CSVFileName.Split(new char[] { '\n' });

        if (count == 0)
        {
            textData.NewMemory(csvFile.Length, Maxrow, Maxcol);
            count++;
        }

        for (int i = 1; i < row.Length; i++)   // data[0] = {'ID', 'ĳ���� �̸�', '���'}
        {
            string[] col = row[i].Split(new char[] { ',' });
            // �ʱ�ȭ
            
            // �������̽� Ȱ���Ͽ� ������ ��ȭ
            for(int j = 0 ; j < col.Length ; j++)
                textData.SetDialogueData(textNum, i, j, col[j]);
        }
        textData.SetDialogueData(textNum, 0, 0, splitdata[0]);
    }
}
