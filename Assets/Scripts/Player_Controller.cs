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
    [SerializeField] private bool canJump;
    [SerializeField] private Animator animator;
    [SerializeField] float up=5;
    [SerializeField] private LayerMask chao;
    [SerializeField] private float raiochao=1.5f;

    //[SerializeField] private EventInstance footsteps;

    public EventReference foot;

    public EventInstance FootSteps;
    public EventReference SomPulo;
    // Start is called before the first frame update
    void Start()
    {
        animator=GetComponent<Animator>();
        rb=GetComponent<Rigidbody2D>();
        //footsteps = AudioManager.Instance.CreateEventInstance(FMODEvents.Instance.footsteps);
        FootSteps=RuntimeManager.CreateInstance(foot);
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
            animator.SetBool("OnGround", false);
            animator.SetBool("OnAir", true);
            //AudioManager.Instance.PlayOneShot(FMODEvents.Instance.Jump, this.transform.position);
            PlayOneShot(SomPulo, this.transform.position);
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
            //Debug.Log("esta encostando");
            canJump=true;
            animator.SetBool("OnGround", true);
            animator.SetBool("OnAir", false);
            PLAYBACK_STATE playbackState;
            //footsteps.getPlaybackState(out playbackState);
            FootSteps.getPlaybackState(out playbackState);
            if(playbackState.Equals(PLAYBACK_STATE.STOPPED))
            {
                FootSteps.start();
            }
        }
        else
        {
            canJump=false;
            FootSteps.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        }
        Debug.DrawRay(transform.position,Vector2.down*1.1f,Color.red);
    }
    public void PlayOneShot(EventReference Pular, Vector3 WorldPos )
    {
        RuntimeManager.PlayOneShot(Pular, WorldPos);
    }
}
