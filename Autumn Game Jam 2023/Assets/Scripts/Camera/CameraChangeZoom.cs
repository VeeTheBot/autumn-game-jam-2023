/*
    Editors: Manhattan Calabro
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChangeZoom : MonoBehaviour
{
    // The camera controller
    [SerializeField] private CameraController cameraController;
    // The new zoom
    [SerializeField] private float newZoom;
    
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag.Equals("Player"))
        {
            cameraController.SetZoom(newZoom);
        }
    }
}
