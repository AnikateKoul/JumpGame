using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private Animator anim;
    [SerializeField] private LayerMask jumpableGround;
    private float dirx = 0f; 
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;
    private enum MovementState { idle, running, jumping, falling };
    private SpriteRenderer sprite;
    
    [SerializeField] private AudioSource jumpSoundEffect;
    // Start is called before the first frame update
    private void Start()
    {
        rb =GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        dirx = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirx*moveSpeed, rb.velocity.y);
        if((Input.GetButtonDown("Jump")) && (isGrounded())) {
            jumpSoundEffect.Play();
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        // if(rb.position.y < -10f) {
        //     Die();
        //     rb.position = new Vector2(-4.03f, 0.57f);

        // }
        // if(Input.GetButtonDown("Horizontal")) {
        //     rb.velocity = new Vector2(7*dirx, 0);
        // }
        UpdateAnimation();
    }

    private void UpdateAnimation()
    {
        MovementState state;
        if((dirx > 0f) || (dirx < 0f)) {
            state = MovementState.running;
            if(dirx < 0f) {
                sprite.flipX = true;
            }
            else {
                sprite.flipX = false;
                
            }
        } 
        else {
            state = MovementState.idle;
        }

        if(rb.velocity.y > 0.1f) state = MovementState.jumping;
        else if(rb.velocity.y < -0.1f) state = MovementState.falling;

        anim.SetInteger("state", (int)state);
    }

    private bool isGrounded() {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0, Vector2.down, 0.1f, jumpableGround);
    }


}
