using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inputs : MonoBehaviour
{
    public float Direction;
    public bool Dash;
    public bool Jump;
    public bool Interact;
    public bool Attack;
    void Update()
    {
        //WASD
        Direction = Input.GetAxisRaw("Horizontal");
        //Dash
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Dash = true;
        }
        else
        {
            Dash = false;
        }
        //Jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump = true;
        }
        else
        {
            Jump = false;
        }
        //Interact
        if (Input.GetKeyDown(KeyCode.E))
        {
            Interact = true;
        }
        else
        {
            Interact = false;
        }
        //Attack
        if (Input.GetKey(KeyCode.Mouse0))
        {
            StartCoroutine(Attacking());
        }
        IEnumerator Attacking()
        {
            Attack = true;
            yield return new WaitForSeconds(1);
            Attack = false;
        }
    }
}
