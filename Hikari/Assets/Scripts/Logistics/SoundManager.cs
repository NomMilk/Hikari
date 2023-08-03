using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{   
    //won't be able to work with the input system I have set up
    //which is a bit of a shame, hopefully I can set it up with the input system
    //OH WAIT GIVE ME AS ECOND

    [SerializeField] private AudioSource Punch;
    [SerializeField] private AudioSource Walk;
    [SerializeField] private AudioSource Dash;

    private bool WalkingSound;


    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    public void PlayPunch(bool Idle)
    {
        if (Idle)
        {
            Punch.mute = false;
            Punch.pitch = 2;
        }
        else
        {
            Punch.mute = false;
            Punch.pitch = 1.5f;
        }
    }   
    public void StopPunch()
    {
        Punch.mute = true;
    }
    public void PlayDash()
    {
        Dash.Play();
    }
    public void PlayWalk(bool IsWalking)
    {
        if (!IsWalking)
        {
            Walk.mute = true;
        }
        else
        {
            Walk.mute = false;
        }
    }
}
