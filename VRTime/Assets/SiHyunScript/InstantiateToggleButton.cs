using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEditor.UI;
using TMPro;
using System.Text;
using UnityEngine.UI;

public class InstantiateToggleButton : MonoBehaviour
{
    public IReadTextData readTextData;
    public GameObject parant;

    void Start()
    {
        readTextData = new ReadTextData();
        GameObject togglePrafab = Resources.Load<GameObject>("prefabs/Toggle");
        ToggleGroup toggleGroup = gameObject.AddComponent<ToggleGroup>();


        string examNumber = this.name.Replace("testPanel", "");
        int num = int.Parse(examNumber);

        if (togglePrafab != null)
        {
            for (int i = 0; i < 5; i++)
            {
                TextData textData = new TextData();
                string dialogueText = textData.GetDialogueData(0, num, 3 + i);
                
                if (dialogueText != null)
                {
                    GameObject toggleObject = Instantiate(togglePrafab, parant.transform);
                    Toggle toggle = toggleObject.GetComponent<Toggle>();
                    
                    SingleCharPrinter singleCharPrinter = toggleObject.GetComponent<SingleCharPrinter>();
                    
                    if (singleCharPrinter != null)
                    {
                        toggle.group = toggleGroup;
                        toggleGroup.allowSwitchOff = false;

                        Image background = toggleObject.transform.Find("Background").GetComponent<Image>();
                        if (background != null)
                        {
                            string imagePath = "NumberImage/" + (i + 1).ToString(); // 파일명은 1, 2, 3...으로 가정
                            Sprite backgroundImage = Resources.Load<Sprite>(imagePath);
                            if (backgroundImage != null)
                            {
                                background.sprite = backgroundImage;
                                background.gameObject.SetActive(true);
                            }
                            else
                            {
                                Debug.LogWarning("Image not found at path: " + imagePath);
                            }
                        }

                        singleCharPrinter.text = dialogueText;
                        TMP_Text textObject = toggleObject.GetComponentInChildren<TMP_Text>();
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
                }
            }
        }
        else
        {
            Debug.LogError("프리팹을 로드할 수 없습니다.");
        }
    }
}