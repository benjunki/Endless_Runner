using System.Collections;
using System.Collections.Generic;
using FMOD.Studio;
using FMODUnity;
using UnityEngine;

public class musicScript : MonoBehaviour
{
    [SerializeField] private EventReference musicRef;
    EventInstance musica;
    WorldTime world;
    float pvalue;
    // Start is called before the first frame update
    void Start()
    {
        world=FindObjectOfType<WorldTime>();
        musica=RuntimeManager.CreateInstance(musicRef);
        musica.start();    
    }

    public void SetParameter(string parameterName, float parameterValue)
    {
        musica.setParameterByName(parameterName, parameterValue);  
    }

    // Update is called once per frame
    void Update()
    {
        if(WorldTime.Instance.state==1)
        {
            musica.setParameterByName("EQ", 1f); 
            //Debug.Log("era pra abafar");
        }
        else if(WorldTime.Instance.state==0)
        {
            musica.setParameterByName("EQ", 0f); 
            //Debug.Log("era pra soar melhor");
        }
    }
}
