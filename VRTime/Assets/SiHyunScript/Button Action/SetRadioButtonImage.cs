using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SetRadioButtonImage : MonoBehaviour
{

    public GameObject togglePrefab;
    public Transform toggleParent;
    public ToggleGroup toggleGroup;

    // Start is called before the first frame update
    void Start()
    {
        GenerateToggles();
    }

    void GenerateToggles()
    {
        int toggleCount = toggleParent.childCount;


        // 기존의 자식 오브젝트 제거
        foreach (Transform child in toggleParent)
        {
            Destroy(child.gameObject);
        }

        for (int i = 0; i < toggleCount; i++)
        {
            GameObject newToggleObject = Instantiate(togglePrefab, toggleParent);
            Toggle newToggle = newToggleObject.GetComponent<Toggle>();
            newToggle.group = toggleGroup;

            // 파일명을 기반으로 배경 이미지 설정
            Image background = newToggleObject.transform.Find("Background").GetComponent<Image>();
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

            Text label = newToggleObject.GetComponentInChildren<Text>();
            if (label != null)
            {
                label.gameObject.SetActive(true);
            }

            // 토글 컴포넌트 비활성화
            newToggle.enabled = true;
        }

    }
}