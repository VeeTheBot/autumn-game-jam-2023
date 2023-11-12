/*
    Editors: Manhattan Calabro
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowPlayerPerma : MonoBehaviour
{
    // New speed
    [SerializeField] private float newSpeedModifier;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag.Equals("Player"))
        {
            collider.GetComponent<PlayerMovement>().ModifySpeed(newSpeedModifier);
            Destroy(this);
        }
    }
}
