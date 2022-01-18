using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
     private float speed=15;
    private bool hit;
    

    private BoxCollider2D boxCollider;
    private Animator anim;
    private float direction;

    private void Awake() {
        anim= GetComponent<Animator>();
        boxCollider=GetComponent<BoxCollider2D>();

    }
    private void Update() {
        if(hit)return;
        float movementspeed = speed*Time.deltaTime*direction;
        transform.Translate(movementspeed,0,0);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        hit=true;
        boxCollider.enabled=false;
        anim.SetTrigger("explode");
        if(collision.tag=="Enemy"){
            collision.GetComponent<Health_Lvl6>().TakeDamage(1);
        }
    }

    public void SetDirection(float dir){
        direction=dir;
        gameObject.SetActive(true);
        hit=false;
        boxCollider.enabled=true;

        float localScaleX = transform.localScale.x;
        if(Mathf.Sign(localScaleX)!=dir){
            localScaleX=-localScaleX;
        }
        transform.localScale=new Vector3(localScaleX,transform.localScale.y,transform.localScale.z);
    }

    public void Deactivate(){
        gameObject.SetActive(false);
    }

    private void DeactivateTime(){
        
    }
}
