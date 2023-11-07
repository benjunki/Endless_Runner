using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class Player_Controller : MonoBehaviour
{
    [SerializeField]Rigidbody2D rb;
    bool canJump;
    [SerializeField]float up=5;
    [SerializeField] private LayerMask chao;
    [SerializeField] private float raiochao=1.5f;

    [SerializeField] private EventInstance footsteps;
    [SerializeField] private EventInstance jump;
    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        footsteps = AudioManager.Instance.CreateEventInstance(FMODEvents.Instance.footsteps);
    }

    // Update is called once per frame
    void Update()
    {
        Raycast();
        Pular();
    }

    void Pular()
    {
        if(Input.GetKeyDown("space")&&canJump==true)
        {
            AudioManager.Instance.PlayOneShot(FMODEvents.Instance.Jump, this.transform.position);
            rb.velocity=Vector2.up*up;
        }
        else
        {
            return;
        }
    }
    void Raycast()
    {
        RaycastHit2D jumphit = Physics2D.Raycast(transform.position, Vector2.down,raiochao, chao);
        if(jumphit)
        {
            canJump=true;
            PLAYBACK_STATE playbackState;
            footsteps.getPlaybackState(out playbackState);
            if(playbackState.Equals(PLAYBACK_STATE.STOPPED))
            {
                footsteps.start();
            }
        }
        else
        {
            canJump=false;
            footsteps.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        }
        Debug.DrawRay(transform.position,Vector2.down*1.1f,Color.red);
    }
}
