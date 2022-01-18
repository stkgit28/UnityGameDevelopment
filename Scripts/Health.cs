using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    // Start is called before the first frame update
     [SerializeField]private float startingHealth;
     public float currentHealth{get;private set;}
     private Animator anim;

     private void Awake() {
         anim = GetComponent<Animator>();
         currentHealth = startingHealth;
     }

    public void TakeDamage(float dmg){
        currentHealth= Mathf.Clamp(currentHealth-dmg,-1,startingHealth);

        if(currentHealth>=0){
            anim.SetTrigger("hurt");
        }
        else{
            anim.SetTrigger("die");

        }
    }

    public void SetHealth(float health)
    {
        currentHealth = health;
    }

    public float SaveHealth()
    {
        return currentHealth;
    }

    private void Restart()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            //currentHealth = 3;
            Time.timeScale=1;
        }
    }


}
