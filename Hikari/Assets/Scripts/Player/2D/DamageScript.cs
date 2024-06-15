using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageScript : MonoBehaviour
{
    public int Damage;
    private int SetDamage;
    [SerializeField] Inputs Inputs;
    [SerializeField] Animator Animator;

    [SerializeField] private bool Attacking;
    private bool IsIdle;
    private static readonly int IsRunningHash = Animator.StringToHash("IsRunning");

    void Start()
    {
        Damage = 10;
        SetDamage = Damage;
        Attacking = false;
    }

    void FixedUpdate()
    {
        IsIdle = !Animator.GetBool(IsRunningHash);
        Damage = IsIdle ? SetDamage + 10 : SetDamage;

        if (Inputs.Attack && Attacking)
        {
            print(Damage);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Attackable"))
        {
            Attacking = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Attackable"))
        {
            Attacking = false;
        }
    }
}
