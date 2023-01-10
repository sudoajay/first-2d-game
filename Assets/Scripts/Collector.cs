using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{

        private string ENEMY_TAG = "Enemy";


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag(ENEMY_TAG))
             Destroy(collision.gameObject);
    }
}
