/*
    Editors: Manhattan Calabro
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameOverDisplay : MonoBehaviour
{
    public void Display()
    {
        // Goes through the children and enables them
        foreach(Transform child in GetComponentsInChildren<Transform>(true))
        {
            child.gameObject.SetActive(true);
        }
    }
}
