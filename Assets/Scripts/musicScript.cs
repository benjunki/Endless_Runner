using System.Collections;
using System.Collections.Generic;
using FMOD.Studio;
using FMODUnity;
using UnityEngine;

public class musicScript : MonoBehaviour
{
    [SerializeField] private EventReference musicRef;
    EventInstance musica;
    // Start is called before the first frame update
    void Start()
    {
        musica=RuntimeManager.CreateInstance(musicRef);
        musica.start();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
