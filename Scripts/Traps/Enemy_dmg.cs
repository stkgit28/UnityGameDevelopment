using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_dmg : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] protected float damage=1;

    protected void OnTriggerEnter2D(Collider2D collision) {
        if(collision.tag=="Player"){
            collision.GetComponent<Health_Lvl6>().TakeDamage(damage);
        }
    }
}
