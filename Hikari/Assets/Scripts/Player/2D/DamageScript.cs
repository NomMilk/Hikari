using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageScript : MonoBehaviour
{
    public int Damage;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Attackable")
        {
            print("Attacked");
        }
    }
}
