using System.Collections;
using System.Collections.Generic;
using Firebase.Auth;
using UnityEngine;

public class FirebaseUsserAuth : MonoBehaviour
{

    public static void CreateNewUsser(string _email, string _password)
    {
        auth.CreateUserWithEmailAndPasswordAsync(_email, _password).ContinueWith(task => {
            if (task.IsCanceled)
            {

                Debug.LogError("CreateUserWithEmailAndPasswordAsync was canceled.");
                return;
            }
            if (task.IsFaulted)
            {
                Debug.LogError("CreateUserWithEmailAndPasswordAsync encountered an error: " + task.Exception);
                return;
            }

            // Firebase user has been created.
            FirebaseUser newUser = task.Result;
            Debug.LogFormat("Firebase user created successfully: {0} ({1})",
                newUser.DisplayName, newUser.UserId);
        });
    }

    public static void ConectCreatedUsser(string _email, string _password)
    {
        auth.SignInWithEmailAndPasswordAsync(_email, _password).ContinueWith(task => {
            if (task.IsCanceled)
            {
                Debug.LogError("SignInWithEmailAndPasswordAsync was canceled.");
                return;
            }
            if (task.IsFaulted)
            {
                Debug.LogError("SignInWithEmailAndPasswordAsync encountered an error: " + task.Exception);
                return;
            }

            FirebaseUser newUser = task.Result;
            Debug.LogFormat("User signed in successfully: {0} ({1})",
                newUser.DisplayName, newUser.UserId);
        });
    }

    static FirebaseAuth auth = FirebaseAuth.DefaultInstance;

}
