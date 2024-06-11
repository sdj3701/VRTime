using UnityEngine;
using UnityEngine.UI;

public class IsToggleOn : MonoBehaviour
{
    private Toggle toggle;

    private void Start()
    {
        // 토글 컴포넌트 찾기
        toggle = GetComponent<Toggle>();

        // 토글 이벤트 리스너 등록
        toggle.onValueChanged.AddListener(OnToggleValueChanged);
    }

    private void OnToggleValueChanged(bool isOn)
    {
        Image image = toggle.transform.Find("Background").GetComponent<Image>();
        Text text = toggle.transform.Find("Label").GetComponent<Text>();

        if (isOn)
        {
            image.color = Color.yellow;
            text.color = Color.yellow;
        }
        else
        {
            image.color = Color.white;
            text.color = Color.white;
        }
    }
}