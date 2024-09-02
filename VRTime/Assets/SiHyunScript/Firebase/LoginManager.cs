using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Auth;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LoginManager : MonoBehaviour
{
    private FirebaseAuth auth;
    public TMP_InputField emailInputField;
    public TMP_InputField passwordInputField;

    // Start is called before the first frame update
    void Start()
    {
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
        {
            FirebaseApp app = FirebaseApp.DefaultInstance;
            auth = FirebaseAuth.DefaultInstance;
        });
    }

    public void LoginWithEmailPassword(string email, string password)
    {
        auth.SignInWithEmailAndPasswordAsync(email, password).ContinueWith(task =>
        {
            if (task.IsCanceled || task.IsFaulted)
            {
                // �α��� ����
                Debug.LogError("�α��� ����: " + task.Exception);
                // ���� �� ��� �޽��� ���
                ShowLoginFailedMessage();
                return;
            }

            // �α��� ����
            FirebaseUser user = task.Result.User;
            Debug.LogFormat("����� {0}��(��) �α����߽��ϴ�.", user.Email);
            // ���� ������ �̵��ϰų� �ٸ� �۾��� ������ �� ����
            MoveToNextScene();
        });
    }

    void ShowLoginFailedMessage()
    {
        // �α��� ���� �� ��� �޽����� ǥ���ϴ� �Լ�
        Debug.LogWarning("�α��ο� �����߽��ϴ�. �ٽ� �õ��� �ּ���.");
    }

    public void OnLoginButtonClicked()
    {
        string email = emailInputField.text;
        string password = passwordInputField.text;
        LoginWithEmailPassword(email, password);
    }
    void MoveToNextScene()
    {
        SceneManager.LoadScene("Prototype");
    }

}
