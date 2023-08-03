using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageScript : MonoBehaviour
{
    public int Damage;
    [SerializeField] Inputs Inputs;

    [SerializeField]private bool Attacking;
    
    void Start()
    {
        Damage = 50;
        Attacking = false;
    }
    void Update()
    {
        if(Inputs.Attack == true)
        {
            if (Attacking == true)
            {
                print("Work");
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
