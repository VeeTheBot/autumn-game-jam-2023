/*
    Editors: Manhattan Calabro
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneDisplay : MonoBehaviour
{
    // The array of images to enable
    [SerializeField] private GameObject[] images;
    // The current index
    private int index = 0;
    // Level to load
    [SerializeField] private LoadLevel loadLevel;

    public void Next()
    {
        index++;
        if(index < images.Length)
        {
            images[index].SetActive(true);
        }
        else
        {
            loadLevel.OpenLevel();
        }
    }
}
