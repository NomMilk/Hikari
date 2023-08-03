using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageScript : MonoBehaviour
{
    public int Damage;
    private int SetDamage;
    [SerializeField] Inputs Inputs;
    [SerializeField] Animator Animator;

    private bool Attacking;
    private bool IsIdle;
    
    void Start()
    {
        Damage = 50;
        SetDamage = Damage;
        Attacking = false;
    }
    void Update()
    {
        IsIdle = !Animator.GetBool("IsRunning");
        if (IsIdle == true)
        {
            Damage = SetDamage+20;
        }
        else
        {
            Damage = SetDamage;
        }
        if(Inputs.Attack == true)
        {
            if (Attacking == true)
            {
                print(Damage);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Attackable")
        {
            Attacking = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Attackable")
        {
            Attacking = false;
        }
    }
}
