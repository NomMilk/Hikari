using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    public Rigidbody2D body;
    public int speed;
    public SpriteRenderer position;
    public Animator Animator;
    public int DashSpeed;
    public float DashDuration;

    //Dash Variables
    public float DashDelay;
    private bool CanDash;
    private bool IsDashing;
    private float DashSet;
    private int tempspeed;
    private float UniversalHorizontal;

    private float Horizontal;

    void Start()
    {
        CanDash = true;
        tempspeed = speed;
        DashSet = 0;
    }
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

        if(Input.GetKeyDown(KeyCode.LeftShift)&&(CanDash))
        {
            StartCoroutine(Dashing());
        }

        if (IsDashing == true)
        {
            Animator.SetBool("IsDashing",true);
            UniversalHorizontal = DashSet;
        }
        else
        {
            Animator.SetBool("IsDashing",false);
            UniversalHorizontal = Horizontal;
        }
    }
    IEnumerator Dashing()
    {
        DashSet = Horizontal;
        if (DashSet == 0)
        {
            if (position.flipX == true)
            {
                DashSet = -1;
            }
            else
            {
                DashSet = 1;
            }
        }
        CanDash = false;
        IsDashing = true;
        speed = DashSpeed;
        yield return new WaitForSeconds(DashDuration);
        speed = tempspeed;
        IsDashing = false;
        yield return new WaitForSeconds(DashDelay);
        CanDash = true;
    }
    void FixedUpdate()
    {
        body.velocity = new Vector2 (speed*UniversalHorizontal, body.velocity.y);
    }
}
