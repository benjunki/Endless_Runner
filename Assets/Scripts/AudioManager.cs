using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;
using System.Diagnostics.Tracing;
using Unity.VisualScripting;

public class AudioManager : MonoBehaviour
{
    private EventInstance musicEventInstance;
    public static AudioManager Instance {get; private set;}

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
        InitializeMusic(FMODEvents.Instance.Music);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InitializeMusic(EventReference musicEventReference)
    {
        musicEventInstance = CreateEventInstance(musicEventReference);
        musicEventInstance.start();
    }
    public EventInstance CreateEventInstance(EventReference eventReference)
    {
        EventInstance eventInstance = RuntimeManager.CreateInstance(eventReference);
        return eventInstance;
    }

    public void PlayOneShot(EventReference Oneshotsound, Vector3 worldPos)
    {
        RuntimeManager.PlayOneShot(Oneshotsound, worldPos);
    }
}
