using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private enum PlayerState
    {
        Ground,
        Jump
    }

    [SerializeField] private float Speed = 500f;
    [SerializeField] private float JumpForce = 500f;

    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;
    private Animator animator;


    private PlayerState сurrentState;
    private Vector2 input;
    private Vector2 prevInput;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void SetState(PlayerState newState)
    {
        if (Equals(newState, сurrentState))
            return;
        сurrentState = newState;
        switch (сurrentState)
        {
            case PlayerState.Ground:
                break;
            case PlayerState.Jump:
                rb.AddForce(Vector2.up * JumpForce);
                break;
        }
    }
    private void Update()
    {
        input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        if(Input.GetButton("Horizontal"))
            spriteRenderer.flipX = input.x < 0;

        animator.SetFloat("speedX", Mathf.Abs(input.x));
        animator.SetBool("jump", сurrentState == PlayerState.Jump);
        if (Input.GetKeyDown(KeyCode.Space) && сurrentState == PlayerState.Ground)
        {
            SetState(PlayerState.Jump);
        } 
    }
    private void FixedUpdate()
    {
        var vel = rb.velocity;
        vel.x = input.x * Time.fixedDeltaTime * Speed;
        rb.velocity = vel;
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            SetState(PlayerState.Ground);
        }
    }







}
