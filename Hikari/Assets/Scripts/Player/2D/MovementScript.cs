using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    public Rigidbody2D body;
    public float speed;
    public SpriteRenderer position;
    public float DashSpeed;
    public float DashDuration;

    //Dash Variables
    public float DashDelay;
    private bool CanDash;
    public bool IsDashing;
    private float DashSet;
    private float tempspeed;
    private float UniversalHorizontal;

    //Jump variables
    public float jumpForce;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    public bool InAir;


    //Inputs
    [SerializeField] private Inputs Inputs;

    void Start()
    {
        CanDash = true;
        tempspeed = speed;
        DashSet = 0;
    }
    void Update()
    {

        if(Inputs.Dash && (CanDash))
        {
            StartCoroutine(Dashing());
        }

        if (IsDashing == true)
        {
            UniversalHorizontal = DashSet;
        }
        else
        {
            UniversalHorizontal = Inputs.Direction;
        }
        // Jumping
        if (IsGrounded() && Inputs.Jump)
        {
            body.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
        if(Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround))
        {
            InAir = true;
        }
        else
        {
            InAir = false;
        }
    }
    public bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }
IEnumerator Dashing()
{
    DashSet = Inputs.Direction;
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
    
    float currentSpeed = 0f;
    float accelerationRate = DashSpeed / DashDuration; // Calculate the rate of acceleration.
    
    while (currentSpeed < DashSpeed)
    {
        currentSpeed += accelerationRate * Time.deltaTime; // Increase the speed over time.
        speed = currentSpeed;
        yield return null; // Wait for the next frame update.
    }
    
    speed = DashSpeed; // Ensure the speed reaches the exact DashSpeed.
    
    yield return new WaitForSeconds(DashDuration);
    
    currentSpeed = DashSpeed;
    while (currentSpeed > tempspeed)
    {
        currentSpeed -= accelerationRate * Time.deltaTime; // Decrease the speed over time.
        speed = currentSpeed;
        yield return null; // Wait for the next frame update.
    }
    
    speed = tempspeed; // Ensure the speed returns to the original value.
    IsDashing = false;
    
    yield return new WaitForSeconds(DashDelay);
    
    CanDash = true;
}
    void FixedUpdate()
    {
        body.velocity = new Vector2 (speed*UniversalHorizontal, body.velocity.y);
    }
}
