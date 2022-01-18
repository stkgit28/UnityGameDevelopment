using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField]private float attackCooldown;
    private Animator anim;

    
    private AnimationPLayerController playerMovement;

    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] fireballs;

    private float cooldownTimer=Mathf.Infinity;

    private void Awake() {
        anim=GetComponent<Animator>();
        playerMovement=GetComponent<AnimationPLayerController>();

    }

    private void Update() {
        if(Input.GetMouseButton(0)&&cooldownTimer>attackCooldown&& playerMovement.canAttack()){
            Attack();
        }
        cooldownTimer+=Time.deltaTime;
        
    }


    private void Attack(){
        anim.SetTrigger("attack");
        cooldownTimer=0;
        if(FindFireball()==0){
            deactivateChain();
        }
        //folosesc object pooling pt optimizare
        fireballs[FindFireball()].transform.position=firePoint.position;
        fireballs[FindFireball()].GetComponent<Projectile>().SetDirection(Mathf.Sign(transform.localScale.x));
        
    }

    private int FindFireball(){
        for(int i=0;i<fireballs.Length;i++){
            if(!fireballs[i].activeInHierarchy){
                return i;
            }
        }
        return 0;
    }

   private void deactivateChain(){
       for(int i=0;i<fireballs.Length;i++){
            fireballs[i].GetComponent<Projectile>().Deactivate();
        }
   }

}