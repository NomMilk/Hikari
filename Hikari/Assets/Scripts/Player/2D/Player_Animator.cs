using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Animator : MonoBehaviour
{
    public Animator Animator;
    [SerializeField] private Inputs Inputs;
    [SerializeField] private MovementScript Move;
    void Update()
    {
        if (Inputs.Direction > 0)
        {
            Animator.SetBool("IsRunning",true);
        }
        else if (Inputs.Direction < 0)
        {
            Animator.SetBool("IsRunning",true);
        }
        else
        {
            Animator.SetBool("IsRunning",false);
        }

        if (Move.IsDashing == true)
        {
             Animator.SetBool("IsDashing",true);
        }
        else
        {
            Animator.SetBool("IsDashing",false);
        }
        if (Inputs.Attack == true)
        {
            StartCoroutine(Attacking());
        }
        IEnumerator Attacking()
        {
            Animator.SetBool("IsAttacking",true);
            yield return new WaitForSeconds(0.4f);
            Animator.SetBool("IsAttacking",false);
        }
    }
}
