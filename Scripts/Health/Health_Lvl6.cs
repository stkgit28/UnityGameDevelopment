using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health_Lvl6 : MonoBehaviour
{
    // Start is called before the first frame update
     [SerializeField]private float startingHealth;
     public float currentHealth{get;private set;}
     private Animator anim;


     private void Awake() {
        currentHealth=startingHealth;
        anim=GetComponent<Animator>();
    }

     private void Update()
     {
         Restart();
     }

     public void TakeDamage(float dmg){
        currentHealth= Mathf.Clamp(currentHealth-dmg,-1,startingHealth);
        
        if(currentHealth>=0){
            anim.SetTrigger("hurt");
        }
        else{
                anim.SetTrigger("die");
            if (GetComponent<AnimationPLayerController>() != null)
            {
                if (GetComponent<AnimationPLayerController>().alive)
                {
                    
                    GetComponent<AnimationPLayerController>().alive = false;
                    
                }
            }
            else{
                
                if (GetComponent<EnemyPatrol>() != null)
                {
                    


                }

                if (GetComponent<MeleeEnemy>() != null)
                {
                    GetComponent<MeleeEnemy>().killed();
                    
                }
                if (GetComponent<RangedEnemy>() != null)
                {
                    
                    
                }

                
            }

        }
    }
    

    public void AddHealth(float hp){
        currentHealth= Mathf.Clamp(currentHealth+hp,0,startingHealth);
        
       
    }

    private void Restart()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            currentHealth = 3;
            Time.timeScale=1;
        }
    }

    

    
}
