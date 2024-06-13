using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueParse : MonoBehaviour
{
    private ITextData textData;
    private int i = 0;
    public TextAsset[] csvFile = null;

    
    private void Awake()
    {
        textData = new TextData();
        for(i = 0; i < csvFile.Length; i++)
        {
            Parse(csvFile[i].name);
        }
    }

    private Dialogue[] Parse(string _CSVFileName)
    {
        List<Dialogue> dialogueList = new List<Dialogue>();
        TextAsset csvData = Resources.Load<TextAsset>(_CSVFileName);

        string[] data = csvData.text.Split(new char[] { '\n' });
        // CSV ���� �̸��� �ֿ켱���� �ֱ����� �۾�
        string[] splitdata = _CSVFileName.Split(new char[] { ',' });
        textData.SetDialogueData(splitdata);

        for (int i = 1; i < data.Length;)   // data[0] = {'ID', 'ĳ���� �̸�', '���'}
        {
            string[] row = data[i].Split(new char[] { ',' });

            // �������̽� Ȱ���Ͽ� ������ ��ȭ
            textData.SetDialogueData(row);
            //Debug.Log(row[2]);

            if (++i < data.Length)
            {
                ;
            }
        }

        return dialogueList.ToArray();
    }

}
