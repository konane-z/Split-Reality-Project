using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public Rigidbody2D rb;
    public Vector2 movement;
    bool facingRight;
    public Animator anim;
    private Hash hash;
    public int speed = 10;
  


    private void Awake()
    {
        anim = GetComponent<Animator>();
        hash = GameObject.FindGameObjectWithTag("GameController").GetComponent<Hash>();
        anim.SetLayerWeight(1, 1f);
    }

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
        Orientation();
    }

    // FixedUpdate is called at a fixed interval and is used for physics calculations



    //This will be replaced when we add buttons but it is controlling the player based on pos on screen by touch
    void FixedUpdate()
    {
        // Get input for movement
        movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        // Move the player based on touch input
        TouchMove();
    }

    void TouchMove()
    {
        if (Input.touchCount > 0)
        {
            anim.SetFloat("Speed", 2);
            Debug.Log(anim.GetFloat("Speed"));
            // Get the touch position and convert it to world space
            Touch touch = Input.GetTouch(0);
            Vector3 touchPos = Camera.main.ScreenToWorldPoint(touch.position);

            // Calculate the movement direction based on touch position
            Vector2 direction = new Vector2(touchPos.x - transform.position.x, touchPos.y - transform.position.y).normalized;

            // Update the animation speed based on the movement speed
            Debug.Log(hash.speedFloat);
            anim.SetFloat(hash.speedFloat, 2.0f);

            // Move the player using the Rigidbody2D component's MovePosition method
            rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);

            if (touchPos.x - transform.position.x > 0 && facingRight)
            {
                Flip();
            }
            if (touchPos.x - transform.position.x < 0 && !facingRight)
            {
                Flip();
            }
        }
        else
        {
            anim.SetFloat("Speed", 0.0f); ;
        }
    }
    // Fliping the texture
    void Flip()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x = -currentScale.x;
        gameObject.transform.localScale = currentScale;
        facingRight = !facingRight;
    }

    void Orientation()
    {
        if (Input.deviceOrientation == DeviceOrientation.Portrait)
        {
            anim.SetBool("Night", true);
        }
        else if (Input.deviceOrientation == DeviceOrientation.LandscapeLeft)
        {
            anim.SetBool("Night", false);
        }
    }
}