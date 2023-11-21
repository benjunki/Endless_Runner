using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inimigoMov : MonoBehaviour
{
    private float leftEdge;
    // Start is called before the first frame update
    void Start()
    {
        leftEdge=Camera.main.ScreenToWorldPoint(Vector3.zero).x-2f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position +=Vector3.left * (GameManager.Instance.gameSpeed * 1.1f)*Time.deltaTime;
        if (transform.position.x<leftEdge)
        {
            Destroy(gameObject);
        }
    }
}
