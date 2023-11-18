using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class audioEvents : MonoBehaviour
{
    public static audioEvents Instance {get; private set;}

    [field:Header("Footsteps SFX")]
    
    [field:SerializeField]  public EventReference footsteps; 

    [field:Header("JumpSFX")]
    [field:SerializeField]  public EventReference Jump;

    [field:Header("Music")]
    [field:SerializeField]  public EventReference Music;

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
}
