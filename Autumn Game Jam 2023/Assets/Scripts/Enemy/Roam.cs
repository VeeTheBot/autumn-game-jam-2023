/*
    Editors: Manhattan Calabro
*/

using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class Roam : MonoBehaviour
{
    // How fast the enemy moves
    [SerializeField] private float baseSpeed = 150;
    // The lower and upper bounds of the enemy's roam
    [SerializeField] private float lowerBound = 0;
    [SerializeField] private float upperBound = 4.85f;
    // Which way the enemy is travelling
    [SerializeField] private bool movingLeft = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Swap directions
        if(transform.position.x < lowerBound)
        {
            movingLeft = false;
        }
        else if(transform.position.x > upperBound)
        {
            movingLeft = true;
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
