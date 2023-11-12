/*
    Editors: Manhattan Calabro
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevelTrigger : MonoBehaviour
{
    // The level loader
    private LoadLevel loadLevel;

    private void Awake()
    {
        loadLevel = GetComponent<LoadLevel>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag.Equals("Player"))
        {
            loadLevel.OpenLevel();
        }
    }
}
