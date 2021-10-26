using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Speed we want char to move
    public float speed = 1;
    // How powerful char can jump
    public float jumpForce = 1;
    // Distance to check from the char to the ground
    public float groundCheckDistance = 0.5f;
    // The sprite
    SpriteRenderer sprite = null;
    // Rigidbody ref for the physics
    Rigidbody2D rb = null;
    // Check if the char is in the air
    bool inAir = false;
    // Direction
    float scaleX = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        // Set base vars
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        scaleX = transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        // Set the speed for left and right but dont mess with up and down
        rb.velocity = Vector2.right * Input.GetAxis("Horizontal") * speed + Vector2.up * rb.velocity.y;

        // Flip the sprite to set direction
        if(Input.GetAxis("Horizontal") != 0) {
            int direction = 1;
            if (Input.GetAxis("Horizontal") < 0) {
                direction = -1;
            }
            transform.localScale = new Vector3(scaleX * direction, transform.localScale.y, transform.localScale.z);
        
        }

        // Make sure char is on the ground by checking the distance from char downwards
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance);
        // If there is ground close enough you arent in the air
        inAir = hit.collider == null;

        // If the char is on the ground and "jump" space bar is pressed the char jumps
        if(!inAir && Input.GetButtonDown("Jump")) {
            transform.position += Vector3.up * 0.1f;
            rb.AddForce(Vector2.up * jumpForce);
        }
    }
}
