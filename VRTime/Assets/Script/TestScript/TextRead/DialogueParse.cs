using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueParse : MonoBehaviour
{
    private ITextData textData;
    
    private void Awake()
    {
        textData = new TextData();
        Parse("dialogue_test_1");
    }

    private Dialogue[] Parse(string _CSVFileName)
    {
        List<Dialogue> dialogueList = new List<Dialogue>();
        TextAsset csvData = Resources.Load<TextAsset>(_CSVFileName);

        string[] data = csvData.text.Split(new char[] { '\n' });

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
