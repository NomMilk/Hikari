using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapMovement : MonoBehaviour
{
    public Rigidbody2D body;
    public int speed;
    private float Horizontal;
    private float Vertical;

    private bool Jump;
    void Update()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");
        Vertical = Input.GetAxisRaw("Vertical");
    }
    void FixedUpdate()
    {
        body.velocity = new Vector2 (speed*Horizontal, speed*Vertical);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("House"))
        {
            SceneManager.LoadScene(1);
        }
    }
}
