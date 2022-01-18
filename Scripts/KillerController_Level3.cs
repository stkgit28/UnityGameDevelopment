using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillerController_Level3 : MonoBehaviour
{
    [SerializeField] private float attackSpeed = 1f;
    private float canAttack;
    private float attackDamage = -100f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
	    if (other.gameObject.CompareTag("Player"))
	    {
		    other.gameObject.GetComponent<PlayerController_Level3>().IsHurt();
	    }
    }
}
