/*
    Editors: Manhattan Calabro
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    // The rigidbody
    private Rigidbody2D body;
    // The player controls
    private PlayerControls playerControls;
    // The sprite renderer
    private SpriteRenderer spriteRenderer;
    // The animator
    private Animator animator;

    // Reference to the movement input action
    private InputAction movement;
    // How fast the player moves
    [SerializeField] private float baseSpeed = 250;
    // How fast the player moves (modified)
    private float modifiedSpeed;

    // Is the player able to jump?
    private bool canJump = true;
    // How high the player jumps
    [SerializeField] private float jumpHeight = 250;

    private void Awake()
    {
        // Fetch the rigidbody
        body = GetComponent<Rigidbody2D>();

        // Fetch new player controls
        playerControls = new PlayerControls();

        // Fetch the sprite renderer
        spriteRenderer = GetComponent<SpriteRenderer>();

        animator = GetComponent<Animator>();

        // Assign the modified speed
        modifiedSpeed = baseSpeed;
    }

    private void OnEnable()
    {
        movement = playerControls.Player.Movement;
        movement.Enable();

        playerControls.Player.Jump.performed += Jump;
        playerControls.Player.Jump.Enable();
    }

    private void OnDisable()
    {
        Die();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Animate();
    }

    private void Move()
    {
        if(movement.enabled)
        {
            // Move the player
            body.velocity = new Vector2(Input.GetAxis("Horizontal") * modifiedSpeed * Time.fixedDeltaTime, body.velocity.y);
        }
    }

    private void Animate()
    {
        if(movement.enabled)
        {
            if(Input.GetAxis("Horizontal") != 0)
            {
                animator.SetBool("Walking", true);

                if(Input.GetAxis("Horizontal") < 0)
                {
                    spriteRenderer.flipX = true;
                }
                else if(Input.GetAxis("Horizontal") > 0)
                {
                    spriteRenderer.flipX = false;
                }
            }
            else
            {
                animator.SetBool("Walking", false);
            }
        }
    }

    private void Jump(InputAction.CallbackContext context)
    {
        Debug.Log("Jump" + context.phase);

        if(canJump)
        {
            Debug.Log("Jumping");

            body.velocity = new Vector2(0, jumpHeight * Time.fixedDeltaTime);
            canJump = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag.Equals("Ground"))
        {
            canJump = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if(collider.tag.Equals("Ground"))
        {
            canJump = false;
        }
    }

    public void ModifySpeed(float modifier)
    {
        modifiedSpeed *= modifier;
    }

    public void ResetSpeed()
    {
        modifiedSpeed = baseSpeed;
    }

    public void Die()
    {
        movement.Disable();
        playerControls.Player.Jump.Disable();
        animator.SetBool("Walking", false);
        body.velocity = Vector2.zero;
    }
}