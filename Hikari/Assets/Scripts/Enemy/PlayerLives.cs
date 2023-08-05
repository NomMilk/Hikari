using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLives : MonoBehaviour
{
    public int Lives;
    [SerializeField] private GameObject Life1;
    [SerializeField] private GameObject Life2;
    [SerializeField] private GameObject Life3;

    void Start()
    {
        Lives = 3;
        Life1.SetActive(true);
        Life2.SetActive(true);
        Life3.SetActive(true);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            Lives--;
        }
    }

    void Update()
    {
        switch(Lives)
        {
            case 0:
                Life1.SetActive(false);
                break;
            case 1:
                Life2.SetActive(false);
                break;
            case 2:
                Life3.SetActive(false);
                break;
            default:
                break;

        }
    }
}
