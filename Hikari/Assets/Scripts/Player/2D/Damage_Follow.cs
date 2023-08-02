using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage_Follow : MonoBehaviour
{
    [SerializeField] private Transform Player;
    [SerializeField] private GameObject Attack;
    [SerializeField] private GameObject Attack1;
    [SerializeField] private SpriteRenderer Renderer;
    void Update()
    {
        Attack.transform.position = Player.position;
        Attack1.transform.position = Player.position;
        if (Renderer.flipX == false)
        {
            Attack.SetActive(true);
            Attack1.SetActive(false);
        }
        else
        {
            Attack.SetActive(false);
            Attack1.SetActive(true);
        }
    }
}
