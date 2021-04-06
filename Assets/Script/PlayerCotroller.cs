using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCotroller : MonoBehaviour
{
    public float speed = 0;
    public float jumpHeight = 10;

    private Rigidbody2D rb;
    private float movementX;
    private bool isJumping = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnMove(InputValue inputValue)
    {
        movementX = inputValue.Get<Vector2>().x;
    }

    private void OnJump(InputValue inputValue)
    {
        if (!isJumping)
        {
            rb.AddForce(new Vector2(0.0f, jumpHeight), ForceMode2D.Impulse);
        }
    }

    private void FixedUpdate()
    {
        rb.AddForce(new Vector2(movementX * speed, 0.0f));
        
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isJumping = true;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        isJumping = false;
    }
}
