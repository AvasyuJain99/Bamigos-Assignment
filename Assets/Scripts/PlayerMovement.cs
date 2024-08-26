using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer playerSprite;
    [SerializeField]
    private float movementSpeed;
    [SerializeField]
    private PlayerAnimations anim;
    [SerializeField]
    private bool isGrounded;
    [SerializeField]
    private float jumpForce;
    private Rigidbody2D rb;
    private float hInput;
    [SerializeField]
    private bool isJumping;
    [SerializeField]
    private float maxJumpTime;
    [SerializeField]
    private float jumpMultiplier;
    private float jumpTimeCounter;
    [SerializeField]
    private ParticleSystem dustParticle;
    public int coins;
    public float health;
    private void Start()
    {
       rb=GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        Movement();
    }
    void Movement()
    {
        hInput = Input.GetAxis("Horizontal");
        anim.Walking(hInput);
        if (hInput != 0)
        {
        dustParticle.Play();
        }
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            isJumping = true;
            jumpTimeCounter = maxJumpTime;
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            anim.Jumping(true);
            dustParticle.Play();
            AudioManager.instance.PlaySfx(AudioManager.instance.sfx[0]);

        }
        rb.velocity = new Vector2(hInput * movementSpeed, rb.velocity.y);
        FlipPlayer(hInput);
        if (!isGrounded)
        {
            dustParticle.Stop();
        }
        if (Input.GetKey(KeyCode.Space) && isJumping)
        {
            if (jumpTimeCounter > 0)
            {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
        }
    }
    void FlipPlayer(float hInput)
    {
        if (hInput > 0)
        {
            playerSprite.flipX = false;
        }
        else if (hInput < 0) 
        {
            playerSprite.flipX = true;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            anim.Jumping(false);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
            anim.Jumping(true);
        }
    }
}
