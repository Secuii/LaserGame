using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Unity.Editor;
using Firebase.Database;

public class DataBaseConectIt : MonoBehaviour
{
    void Start()
    {
        // Set this before calling into the realtime database.
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://guildgametesting.firebaseio.com/");
        // Get the root reference location of the database.
        DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;

        FirebaseDatabase.DefaultInstance
      .GetReference("250LgjqX7ARQ4qBZCbbhkkdTQ453")
      .GetValueAsync().ContinueWith(task => {
          if (task.IsFaulted)
          {
              Debug.LogError(task.Exception);
          }
          else if (task.IsCompleted)
          {
              DataSnapshot snapshot = task.Result;
              Debug.Log(snapshot);
          }
      });
    }
}

