using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; // importing the Input System

public class playerMovement : MonoBehaviour
{
    private Vector2 movement; // variable that stores the character's movement input as a 2D vector
    private Rigidbody2D body; // the character's Rigidbody2D componont used to manipulate physics-related properties
    private Animator myAnimator; // the character's Animator component used to control animations based on movement input

    [SerializeField] private int speed = 5; // variable that defines the characters speed. 
                                            // [SerializeField] makes it editable in Unity without being a public variable

    private void Awake() // method called when the script is initialized
    {
        body = GetComponent<Rigidbody2D>(); // retrieves the Rigidbody2D component attached to the same 
                                            // GameObject as this script and stores a reference to it
        
        myAnimator = GetComponent<Animator>(); // retrieves the Animator component attached to the same
                                              // GameObject as this script and stores a reference to it
    }

    private void OnMovement(InputValue value) // method handeling the Input System. called whenenver the "Movement" input binding is triggered
    {
        movement = value.Get<Vector2>(); // retrieves the character's movement input as a Vector2 and stores it in the movement variable

        if (movement.x != 0 || movement.y != 0) // if-statement checking if the character is moving.
                                                // if either the x or y component of movement is non-zero, the player is moving
        {
            myAnimator.SetFloat("x", movement.x); // updates the Animator parameter x, with the horizontol movement value (x)
            myAnimator.SetFloat("y", movement.y); // updates the Animator parameter y, with the horizontol movement value (y)
            myAnimator.SetBool("isWalking", true); // sets the parameter "isWalking" to true, triggering the walking animation
        }

        else // else-statement setting the parameter "isWalking" to false, stopping the walking animation
        {
            myAnimator.SetBool("isWalking", false);
        }
    }

    private void FixedUpdate() // method called at fixed intervals 
    {
        body.velocity = movement * speed; // sets the character's velocity based on their input (movement) and movement speed (speed).
                                        // movement determines the direction as a Vector2. speed scales the velocity to control how fast the player moves.
    }
}
