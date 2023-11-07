using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class FMODEvents : MonoBehaviour
{
    public static FMODEvents Instance {get; private set;}

    [field:Header("Footsteps SFX")]
    
    [field:SerializeField] public EventReference footsteps; 

    [field:Header("JumpSFX")]
    [field:SerializeField] public EventReference Jump;

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
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
