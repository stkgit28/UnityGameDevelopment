using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovebackandForth : MonoBehaviour
{
    public float speed = 5f;
    bool switc = true;
    private SpriteRenderer spriteRenderer;
    
    private Vector3 initialPosition;
    
    void Start()
    {
        initialPosition = transform.position;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    
    // Update is called once per frame
    void Update()
    {
        if(switc){
            moveRight();
        }
        if(!switc){
            moveLeft();
        }
        if(transform.position.x >= 7f){
            switc = false;
            spriteRenderer.flipX = true;
        }
        
        if(transform.position.x <= -7f){
            switc = true;
            spriteRenderer.flipX = false;
        }
        ResetPosition();
    }

    void moveRight(){
        transform.Translate(speed*Time.deltaTime,0,0);
    }

    void moveLeft(){
        transform.Translate(-speed*Time.deltaTime,0,0);
    }
    
    void ResetPosition()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            transform.position = initialPosition;
        }

    }
}
