using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class GameManager : MonoBehaviour
{
    public float initialGameSpeed = 25f;

    public float gameSpeedIncrease=.3f;

    public float gameSpeed{get; private set;}


   public static GameManager Instance {get; private set;}

   private void Awake()
   {
    if(Instance==null)
    {
        Instance=this;
    } 
    else
    {
        DestroyImmediate(gameObject);
    }
   }

   private void OnDestroy()
   {
    if(Instance==this)
    {
        Instance=null;
    }
   }

   private void Start()
   {
    
   }

   private void NewGame()
   {
    gameSpeed=initialGameSpeed;
   }
   private void Update()
   {
    gameSpeed+=gameSpeedIncrease*Time.deltaTime;
   }
}
