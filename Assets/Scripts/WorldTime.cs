using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Rendering.Universal;



    [RequireComponent(typeof(Light2D))]

    public class WorldTime: MonoBehaviour
    {
    public static WorldTime Instance {get; private set;}
    private void Awake()
    {
        _mlight = GetComponent<Light2D>();
        _mstartTime = Time.time;
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
        public float state;
        public float duration = 5f;
        [SerializeField]private Gradient _mgradient;
        private Light2D _mlight;
        private float _mstartTime;
        
       

        private void Start()
        {

        }
        private void Update()
        {
            float timeElapsed = Time.time - _mstartTime;
            float percentage = Mathf.Sin(f: timeElapsed/duration*Mathf.PI*2) *0.5f + 0.5f;
            percentage = Mathf.Clamp01(percentage);
            _mlight.color = _mgradient.Evaluate(percentage);
            //Debug.Log(percentage);
            if(percentage>=0.9f)
            {
                state=1;
                //Debug.Log("esta de noite");
            }
            else
            {
                state=0;
                //Debug.Log("esta de dia");
            }
            
        }
    }   

