/*
    Editors: Manhattan Calabro
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    // The name of the scene to load
    [SerializeField] private string levelName;

    public void OpenLevel()
    {
        // Only run if the level name exists
        if(levelName != "")
            SceneManager.LoadScene(levelName);
        else
            Debug.LogError("ERROR: No level name assigned!");
    }

    public void QuitApplication()
    {
        Application.Quit();
    }

    public void SetLevelName(string str)
    {
        levelName = str;
    }
}
