using UnityEngine;
using UnityEngine.UI;

public class IsToggleOn : MonoBehaviour
{
    private Toggle toggle;

    private void Start()
    {
        // ��� ������Ʈ ã��
        toggle = GetComponent<Toggle>();

        // ��� �̺�Ʈ ������ ���
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