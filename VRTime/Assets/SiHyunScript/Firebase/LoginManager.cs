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
            if (task.IsCanceled)
            {
                // 로그인 실패
                Debug.LogError("로그인 실패: " + task.Exception);
                // 실패 시 경고 메시지 출력
                UnityMainThreadDispatcher.Instance().Enqueue(ShowLoginFailedMessage);
                return;
            }
            else if (task.IsFaulted)
            {
                Debug.LogError("로그인 실패: " + task.Exception);
                UnityMainThreadDispatcher.Instance().Enqueue(ShowLoginFailedMessage);
                return;
            }
            else
            {
                // 로그인 성공
                FirebaseUser user = task.Result.User;
                Debug.LogFormat("사용자 {0}이(가) 로그인했습니다.", user.Email);
                // 메인 스레드에서 씬 이동을 수행
                UnityMainThreadDispatcher.Instance().Enqueue(MoveToNextScene);
            }
        });
    }

    void ShowLoginFailedMessage()
    {
        // 로그인 실패 시 경고 메시지를 표시하는 함수
        Debug.LogWarning("로그인에 실패했습니다. 다시 시도해 주세요.");
    }

    public void OnLoginButtonClicked()
    {
        string email = emailInputField.text;
        string password = passwordInputField.text;
        LoginWithEmailPassword(email, password);
    }

    void MoveToNextScene()
    {
        SceneManager.LoadScene("roomTest");
    }
}
