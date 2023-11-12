/*
    Editors: Manhattan Calabro
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roam : MonoBehaviour
{
    // The sprite renderer
    private SpriteRenderer spriteRenderer;
    // How fast the enemy moves
    [SerializeField] private float baseSpeed = 150;
    // The lower and upper bounds of the enemy's roam
    [SerializeField] private float lowerBound = 0;
    [SerializeField] private float upperBound = 4.85f;
    // Which way the enemy is travelling
    [SerializeField] private bool movingLeft = true;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // Swap directions
        if(transform.position.x < lowerBound)
        {
            movingLeft = false;
            spriteRenderer.flipX = true;
        }
        else if(transform.position.x > upperBound)
        {
            movingLeft = true;
            spriteRenderer.flipX = false;
        }

        float movementSpeed = baseSpeed * Time.deltaTime;
        if(movingLeft)
        {
            transform.position += new Vector3(movementSpeed * -1, 0, 0);
        }
        else
        {
            transform.position += new Vector3(movementSpeed * 1, 0, 0);
        }
    }
}
