using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    public Rigidbody2D body;
    public int speed;
    public SpriteRenderer position;
    public Animator Animator;

    private float Horizontal;

    void Update()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");

        if (Horizontal > 0)
        {
            position.flipX = false;
            Animator.SetBool("IsRunning",true);

        }

        else if (Horizontal < 0)
        {
            position.flipX = true;
            Animator.SetBool("IsRunning",true);
        }
        else
        {
            Animator.SetBool("IsRunning",false);
        }
    }
    void FixedUpdate()
    {
        body.velocity = new Vector2 (speed*Horizontal, body.velocity.y);
    }
}
