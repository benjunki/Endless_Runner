using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;
using JetBrains.Annotations;

public class Player_Controller : MonoBehaviour
{
    private GameManager gm;

    private AudioManager am;
    [SerializeField]Rigidbody2D rb;
    [SerializeField] private bool canJump;
    [SerializeField] private Animator animator;
    [SerializeField] float up=5;
    [SerializeField] private LayerMask chao;
    [SerializeField] private float raiochao=1.5f;
    public float jumpTime;
    private float jumpTimeCounter;
    [SerializeField] private bool noar;

    //[SerializeField] private EventInstance footsteps;

    [SerializeField] private EventReference foot;

    EventInstance FootSteps;
    [SerializeField] private EventReference SomPulo;
    // Start is called before the first frame update
    void Start()
    {
        animator=GetComponent<Animator>();
        rb=GetComponent<Rigidbody2D>();
        //footsteps = AudioManager.Instance.CreateEventInstance(FMODEvents.Instance.footsteps);
        FootSteps=RuntimeManager.CreateInstance(foot);
        gm=FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Raycast();
        Pular();
    }

    void Pular()
    {
        if(Input.GetKeyDown("space")&& canJump==true)
        {
            animator.SetBool("OnGround", false);
            animator.SetBool("OnAir", true);
            jumpTimeCounter=jumpTime;
            //AudioManager.Instance.PlayOneShot(FMODEvents.Instance.Jump, this.transform.position);
            PlayOneShot(SomPulo, this.transform.position);
            rb.velocity=Vector2.up*up;
        }
        if(Input.GetKey("space") && canJump==true)
        {
            if(jumpTimeCounter>0)
            {
                rb.velocity=Vector2.up*up;
                jumpTimeCounter-=Time.deltaTime;
            }   
            else if(jumpTimeCounter<=0)
            {
                canJump=false;
            }
        }
        if(Input.GetKeyUp("space"))
        {
            canJump=false;
        }
    }
    public void Raycast()
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
            //canJump=false;
            FootSteps.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        }
        Debug.DrawRay(transform.position,Vector2.down*1.1f,Color.red);
    }
    public void PlayOneShot(EventReference Pular, Vector3 WorldPos )
    {
        RuntimeManager.PlayOneShot(Pular, WorldPos);
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Enemy"))
        {
            GameManager.Instance.GameOver();
        }   
    }
}
