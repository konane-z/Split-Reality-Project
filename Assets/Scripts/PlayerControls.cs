using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerControls : MonoBehaviour
{
    public Rigidbody2D rb;
    public Vector2 movement;
    bool facingRight;
    public Animator anim;
    public int speed = 10;
    public Button upButton;
    public Button downButton;
    public Button leftButton;
    public Button rightButton;
    public Button upButtonNight;
    public Button downButtonNight;
    public Button leftButtonNight;
    public Button rightButtonNight;
    bool upButtonPressed;
    bool downButtonPressed;
    bool leftButtonPressed;
    bool rightButtonPressed;
    bool upButtonNightPressed;
    bool downButtonNightPressed;
    bool leftButtonNightPressed;
    bool rightButtonNightPressed;
    public void OnUpButtonPress()
    {
        upButtonPressed = true;
    }
    public void OnUpButtonRelease()
    {
        upButtonPressed = false;
    }
    public void OnLeftButtonPress()
    {
        leftButtonPressed = true;
    }
    public void OnLeftButtonRelease()
    {
        leftButtonPressed = false;
    }
    public void OnRightButtonPress()
    {
        rightButtonPressed = true;
    }
    public void OnRightButtonRelease()
    {
        rightButtonPressed = false;
    }
    public void OnDownButtonPress()
    {
        downButtonPressed = true;
    }
    public void OnDownButtonRelease()
    {
        downButtonPressed = false;
    }
    public void OnUpButtonNightPress()
    {
        upButtonNightPressed = true;
    }
    public void OnUpButtonNightRelease()
    {
        upButtonNightPressed = false;
    }
    public void OnLeftButtonNightPress()
    {
        leftButtonNightPressed = true;
    }
    public void OnLeftButtonNightRelease()
    {
        leftButtonNightPressed = false;
    }
    public void OnRightButtonNightPress()
    {
        rightButtonNightPressed = true;
    }
    public void OnRightButtonNightRelease()
    {
        rightButtonNightPressed = false;
    }
    public void OnDownButtonNightPress()
    {
        downButtonNightPressed = true;
    }
    public void OnDownButtonNightRelease()
    {
        downButtonNightPressed = false;
    }

    private void Awake()
    {
        anim = GetComponent<Animator>();
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
        Orientation();
    }
    
    void FixedUpdate()
    {
        ButtonMove();
    }

    void ButtonMove()
    {
        float horizontalInput = 0.0f;
        float verticalInput = 0.0f;

        if (upButtonPressed)
        {
            verticalInput += 1.0f;
        }
        if (downButtonPressed)
        {
            verticalInput -= 1.0f;
        }
        if (leftButtonPressed)
        {
            horizontalInput -= 1.0f;
        }
        if (rightButtonPressed)
        {
            horizontalInput += 1.0f;
        }

        // Normalize the input vector so that diagonal movement isn't faster
        Vector2 movementInput = new Vector2(horizontalInput, verticalInput).normalized;

        // Set the animator's speed parameter based on movementInput magnitude
        anim.SetFloat("Speed", movementInput.magnitude);

        // Move the player using the Rigidbody2D component's MovePosition method
        rb.MovePosition(rb.position + movementInput * speed * Time.fixedDeltaTime);

        if (horizontalInput > 0 && !facingRight)
        {
            Flip();
        }
        else if (horizontalInput < 0 && facingRight)
        {
            Flip();
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
        if (Screen.orientation == ScreenOrientation.Portrait || Screen.orientation == ScreenOrientation.PortraitUpsideDown)
        {
            anim.SetBool("Night", true);
        }
        else if (Screen.orientation == ScreenOrientation.LandscapeLeft || Screen.orientation == ScreenOrientation.LandscapeRight)
        {
            anim.SetBool("Night", false);
        }
    }
}