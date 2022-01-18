using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
    private float healthValue =1;


     void OnTriggerEnter2D(Collider2D collision) {
        if(collision.tag=="Player"){
            gameObject.SetActive(false);
            collision.GetComponent<Health_Lvl6>().AddHealth(healthValue);
            
        }
    }

     private void Update()
     {
         if (Input.GetKeyDown(KeyCode.R))
         {
             gameObject.SetActive(true);
         }
     }
}
