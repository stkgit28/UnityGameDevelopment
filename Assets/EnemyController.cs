using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    [SerializeField] private float attackSpeed = 1f;
    private float canAttack;
    private float attackDamage = -20f;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Am facut un enemy");
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnCollisionStay2D(Collision2D other) {
	if(other.gameObject.tag == "Player") {
            if(attackSpeed <= canAttack){
        	Debug.Log("Este un player");
		other.gameObject.GetComponent<PlayerController>().UpdateHealth(attackDamage);	
	    	canAttack = 0f;
	    } else {
		canAttack += Time.deltaTime;
	    }
	}
    }
}
