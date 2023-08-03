using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundListener : MonoBehaviour
{
    [SerializeField] Inputs Inputs;
    private GameObject SoundManager;
    [SerializeField] MovementScript Movement;

    private void Start()
    {
        SoundManager =  GameObject.Find("SoundManager");
    }
    private void Update()
    {
        if (Inputs.Attack)
        {
            if (Inputs.Direction == 0)
            {
                SoundManager.SendMessage("PlayPunch",true);
            }
            else
            {
                SoundManager.SendMessage("PlayPunch",false);
            }
        }
        else
        {
            SoundManager.SendMessage("StopPunch");
        }
        if(Movement.IsDashing)
        {
            SoundManager.SendMessage("PlayDash");
        }
        if(Inputs.Direction != 0 && Movement.InAir)
        {
            SoundManager.SendMessage("PlayWalk",true);
        }
        else
        {
            SoundManager.SendMessage("PlayWalk",false);
        }
    }
}
