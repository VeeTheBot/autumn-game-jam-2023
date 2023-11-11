/*
    Editors: Manhattan Calabro
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag.Equals("Player"))
        {
            Debug.Log("Player dies");

            // Stop the player from moving
            collider.GetComponentInChildren<PlayerMovement>().Die();

            // Show the death screen
            GameObject.FindWithTag("UI").GetComponentInChildren<GameOverDisplay>().Display();
        }
    }
}
