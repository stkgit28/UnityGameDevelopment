using System;
using UnityEngine;

public class LadderMovement : MonoBehaviour
{
    private float climbSpeed = 10f;
    private float climbVelocity;
    private float naturalGravity;

    public bool onLadder;

    [SerializeField] private Rigidbody2D rb;
    private Animator anim;
    
    void Start()
    {
        naturalGravity = rb.gravityScale;
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        Climb();
    }

    private void Climb()
    {
        if (onLadder)
        {
            rb.gravityScale = 0f;
            climbVelocity = climbSpeed * Input.GetAxisRaw("Vertical");
            Debug.Log(climbVelocity);
            rb.velocity = new Vector2(rb.velocity.x, climbVelocity);
            if (rb.velocity.y != 0)
            {
                anim.SetBool("isOnLadder", true);
                anim.SetBool("idle", false);
            }
            else
            { 
                anim.SetBool("isOnLadder", false); 
                anim.SetBool("idle", true);
            }
        }

        if (!onLadder)
        {
            rb.gravityScale = naturalGravity;
            anim.SetBool("isOnLadder", false);
        }
    }
}