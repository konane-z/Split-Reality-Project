using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb;
    public Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Get input for movement
        movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }

    // FixedUpdate is called at a fixed interval and is used for physics calculations
    void FixedUpdate()
    {
        // Move the player based on touch input
        TouchMove();
    }

    void TouchMove()
    {
        if (Input.touchCount > 0)
        {
            // Get the touch position and convert it to world space
            Touch touch = Input.GetTouch(0);
            Vector3 touchPos = Camera.main.ScreenToWorldPoint(touch.position);

            // Calculate the movement direction based on touch position
            Vector2 direction = new Vector2(touchPos.x - transform.position.x, touchPos.y - transform.position.y).normalized;

            // Move the player using the Rigidbody2D component's MovePosition method
            rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);
        }
    }
}