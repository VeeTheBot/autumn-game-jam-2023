/*
    Editors: Manhattan Calabro
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowPlayer : MonoBehaviour
{
    // Speed multiplier
    [SerializeField] private float speedModifier = 0.5f;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag.Equals("Player"))
        {
            Debug.Log("Player slows");

            collider.GetComponent<PlayerMovement>().ModifySpeed(speedModifier);
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if(collider.tag.Equals("Player"))
        {
            Debug.Log("Player not slows");

            collider.GetComponent<PlayerMovement>().ResetSpeed();
        }
    }
}
