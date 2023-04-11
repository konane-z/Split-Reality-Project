using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public Transform playerTransform;
    public float moveSpeed = 2f;
    public float stoppingDistance = 2f;
    private SpriteRenderer spriteRenderer;
    public Animator anim;
    public Torch torch;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        anim.SetLayerWeight(1, 1f);
    }

    private void Update()
    {
        if (playerTransform == null) return;

        float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);

        if (distanceToPlayer > stoppingDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, playerTransform.position, moveSpeed * Time.deltaTime);
            anim.SetBool("Player_Is_Close", true);
            if (playerTransform.position.x < transform.position.x)
            {
                spriteRenderer.flipX = true;
            }
            else
            {
                spriteRenderer.flipX = false;
            }
            if (torch.isHeld)
            {
                // Hide the enemy if the player is holding the torch
                gameObject.SetActive(false);
            }
            else
            {
                // Show the enemy if the player is not holding the torch
                gameObject.SetActive(true);
            }
        }
        else 
        {
            if (distanceToPlayer <= stoppingDistance)
            {
                anim.SetBool("Collided_With_Player", true);
            }
            else
            {
                anim.SetBool("Collided_With_Player", false);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerTransform = other.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerTransform = null;
            anim.SetBool("Player_Is_Close", false);
        }
    }
}
