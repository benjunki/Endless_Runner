using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    [SerializeField]Rigidbody2D rb;
    bool canJump;
    [SerializeField]float up=5;
    [SerializeField] private LayerMask chao;
    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Raycast();
        podePular();
    }

    void podePular()
    {
        if(Input.GetKeyDown("space")&&canJump==true)
        {
            rb.velocity=Vector2.up*up;
        }
        else
        {
            return;
        }
    }
    void Raycast()
    {
        RaycastHit2D jumphit = Physics2D.Raycast(transform.position, Vector2.down,1.1f, chao);
        if(jumphit)
        {
            canJump=true;
        }
        else
        {
            canJump=false;
            Debug.Log("era pra ficar chamando");
        }
        Debug.DrawRay(transform.position,Vector2.down*1.1f,Color.red);
    }
}
