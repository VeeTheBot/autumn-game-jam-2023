/*
    Editors: Manhattan Calabro
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // The camera component
    private Camera camera;
    // The different "modes" the camera can follow
    private enum Mode{ Static, Follow };
    // Which mode the camera is currently in: 0 is static, 1 is follow
    [SerializeField] private int currentMode;
    // The starting position of the camera
    private Vector3 startingPosition;
    // The position the camera should move to
    private Vector3 targetPosition;
    // The starting zoom
    private float startingZoom;
    // How close the camera is to the player (smaller values make a closer camera)
    [SerializeField] private float playerZoom = 3;
    // How long it should take for the camera to move
    [SerializeField] private float movementTime = 0.05f;
    // Refernce to the player
    [SerializeField] private Transform player;
    // The x- and y-bounds of the camera
    [SerializeField] private Vector2 xBounds = Vector2.zero;
    [SerializeField] private Vector2 yBounds = Vector2.zero;

    // Start is called before the first frame update
    void Awake()
    {
        // Fetch the camera
        camera = GetComponent<Camera>();

        // Start in static mode if the current mode doesn't exist
        if(currentMode != (int) Mode.Static && currentMode != (int) Mode.Follow)
            currentMode = (int) Mode.Static;

        // Fetch the starting position
        startingPosition = targetPosition = transform.position;

        // Fetch the starting zoom
        startingZoom = camera.orthographicSize;
    }

    void FixedUpdate()
    {
        // If the camera is in static mode, move to its starting position
        if(currentMode == (int) Mode.Static)
            StaticMovement();
        // Otherwise, if the camera is in follow mode, follow the player's position
        else if(currentMode == (int) Mode.Follow)
            FollowMovement();
        
        // If the camera is not in the correct position...
        if(transform.position != targetPosition)
        {
            // Stores the velocity (here for now because there's no current use for this overall)
            Vector3 velocity = Vector3.zero;

            // Move the camera accordingly
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, movementTime);
        }
    }

    // Perform the movement associated with static mode
    private void StaticMovement()
    {
        targetPosition = startingPosition;
        camera.orthographicSize = startingZoom;
    }

    // Perform the movement associated with follow mode
    private void FollowMovement()
    {
        // Only run if the player exists
        if(player != null)
        {
            targetPosition = BoundedMovement();
            camera.orthographicSize = playerZoom;
        }
    }

    private Vector3 BoundedMovement()
    {
        return new Vector3(
            Mathf.Clamp(player.position.x, xBounds.x, xBounds.y),
            Mathf.Clamp(player.position.y, yBounds.x, yBounds.y),
            startingPosition.z);
    }
}
