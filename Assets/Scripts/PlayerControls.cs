using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerControls : MonoBehaviour
{
    public GameObject torchPrefab;
    private GameObject torchGameObject = null;
    public Rigidbody2D rb;
    public Vector2 movement;
    bool facingRight = true;
    public Animator anim;
    public int speed = 5;
    

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
        if (torchGameObject != null)
        {
            // Set the torch's position and rotation to match the player's hand
            torchGameObject.transform.position = transform.position + transform.right * 0.5f; // Adjust the position to match your character's hand position
            torchGameObject.transform.rotation = transform.rotation; // Set the rotation to match the player's hand rotation
        }
    }
    
    void FixedUpdate()
    {
        ButtonMove();
    }

    public void ButtonMove()
    {
        float horizontalInput = SimpleInput.GetAxisRaw("Horizontal");
        float verticalInput = SimpleInput.GetAxisRaw("Vertical");

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
            anim.SetBool("Night", false);
        }
        else if (Screen.orientation == ScreenOrientation.LandscapeLeft || Screen.orientation == ScreenOrientation.LandscapeRight)
        {
            anim.SetBool("Night", true);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Torch"))
        {
            // Instantiate the torch item and set it as a child of the player
            torchGameObject = Instantiate(torchPrefab, transform.position, transform.rotation);
            torchGameObject.transform.SetParent(transform);
            anim.SetBool("Has_Torch", true);
        }
    }
}