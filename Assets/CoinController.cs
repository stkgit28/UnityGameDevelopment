using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    private float healthIncome = 10f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnCollisionStay2D(Collision2D other) {
	if(other.gameObject.tag == "Player") {
		var pc = other.gameObject.GetComponent<PlayerController>();
		if(pc.GetHealth() != pc.GetMaxHealth()){
		pc.UpdateHealth(healthIncome);	
		Destroy(gameObject);
		}
	}
    }
}
