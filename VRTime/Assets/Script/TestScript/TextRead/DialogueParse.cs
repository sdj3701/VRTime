using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueParse : MonoBehaviour, IReadTextData
{
    public ITextData[] textData { get; set; }
    private int textNum = 0;
    public TextAsset[] csvFile = null;

    
    private void Awake()
    {
        textData = new ITextData[] { };
        for (textNum = 0; textNum < csvFile.Length; textNum++)
        {
            Parse(csvFile[textNum].name);
        }
    }

    private Dialogue[] Parse(string _CSVFileName)
    {
        List<Dialogue> dialogueList = new List<Dialogue>();
        TextAsset csvData = Resources.Load<TextAsset>(_CSVFileName);

        string[] data = csvData.text.Split(new char[] { '\n' });
        // CSV ���� �̸��� �ֿ켱���� �ֱ����� �۾�
        string[] splitdata = _CSVFileName.Split(new char[] { ',' });
        textData[textNum].SetDialogueData(splitdata);

        for (int i = 1; i < data.Length;)   // data[0] = {'ID', 'ĳ���� �̸�', '���'}
        {
            string[] row = data[i].Split(new char[] { ',' });

            // �������̽� Ȱ���Ͽ� ������ ��ȭ
            textData[textNum].SetDialogueData(row);
            //Debug.Log(row[2]);

            if (++i < data.Length)
            {
                ;
            }
        }

        return dialogueList.ToArray();
    }

}
