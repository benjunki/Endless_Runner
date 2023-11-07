using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meio : MonoBehaviour
{
    // Start is called before the first frame update
    private MeshRenderer meshRenderer;
    private void Awake() 
    {
        meshRenderer=GetComponent<MeshRenderer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float speed=GameManager.Instance.gameSpeed / (transform.localScale.x*2);
        meshRenderer.material.mainTextureOffset += Vector2.right*speed*Time.deltaTime;
        
    }
}
