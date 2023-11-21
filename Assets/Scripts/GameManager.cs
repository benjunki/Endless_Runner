using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using UnityEngine.Assertions.Must;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private Player_Controller player;
    private Spawner spawner;
    public float initialGameSpeed = 100f;

    public float gameSpeedIncrease=1f;

    public TextMeshProUGUI gameOverText;

    public Button retrybut;

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
    player=FindObjectOfType<Player_Controller>();
    spawner = FindObjectOfType<Spawner>();
    NewGame();
   
   }

   public void NewGame()
   {
    inimigoMov[] inimigos = FindObjectsOfType<inimigoMov>();
    
    foreach(var inimigo in inimigos)
    {
        Destroy(inimigo.gameObject);
    }
    player.gameObject.SetActive(true);
    spawner.gameObject.SetActive(true);
    gameSpeed=initialGameSpeed;
    enabled=true;
    gameOverText.gameObject.SetActive(false);
    retrybut.gameObject.SetActive(false);
   }
   private void Update()
   {
    gameSpeed+=gameSpeedIncrease*Time.deltaTime;
   }

   public void GameOver()
   {
    gameSpeed=0f;
    enabled=false;
    player.gameObject.SetActive(false);
    spawner.gameObject.SetActive(false);
    retrybut.gameObject.SetActive(true);
    gameOverText.gameObject.SetActive(true);
   }
}
