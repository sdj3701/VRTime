/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Auth;
using Firebase.Database;

public class FirebaseAuthManager : MonoBehaviour
{
    private FirebaseAuth auth;
    private FirebaseUser user;

    // Initialize Firebase
    void Start()
    {
        InitializeFirebase();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void InitializeFirebase()
    {
        auth = FirebaseAuth.DefaultInstance;
    }

    // Method to sign up a new user
    public void SignUp(string email, string password)
    {
        auth.CreateUserWithEmailAndPasswordAsync(email, password).ContinueWith(task =>
        {
            if (task.IsCanceled)
            {
                Debug.LogError("SignUp was canceled.");
                return;
            }
            if (task.IsFaulted)
            {
                Debug.LogError("SignUp encountered an error: " + task.Exception);
                return;
            }

            // Firebase user has been created.
            user = task.Result.User;
            Debug.LogFormat("Firebase user created successfully: {0} ({1})", user.DisplayName, user.UserId);
        });
    }

    // Method to log in an existing user
    public void LogIn(string email, string password)
    {
        auth.SignInWithEmailAndPasswordAsync(email, password).ContinueWith(task =>
        {
            if (task.IsCanceled)
            {
                Debug.LogError("LogIn was canceled.");
                return;
            }
            if (task.IsFaulted)
            {
                Debug.LogError("LogIn encountered an error: " + task.Exception);
                return;
            }

            // Firebase user has logged in.
            user = task.Result.User;
            Debug.LogFormat("User logged in successfully: {0} ({1})", user.DisplayName, user.UserId);
        });
    }

    // Method to log out the current user
    public void LogOut()
    {
        auth.SignOut();
        user = null;
        Debug.Log("User logged out successfully.");
    }
}
*/