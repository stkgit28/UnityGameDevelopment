using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackandForth2_niv4 : MonoBehaviour
{

    public float speed = 6f;
    bool switc = true;
    private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    
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
            moveLeft();           
        }
        if(!switc){
            moveRight();
        }
       
        if(transform.position.x >= 9f){
            switc = true;
            spriteRenderer.flipX = false;
        }
        if(transform.position.x <= -9f){
            switc = false;
            spriteRenderer.flipX = true;
        }
        
        ResetPosition();

    }

    void moveLeft(){
        transform.Translate(-speed*Time.deltaTime,0,0);
    }

    void moveRight(){
        transform.Translate(speed*Time.deltaTime,0,0);
    }
    
    void ResetPosition()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            transform.position = initialPosition;
        }

    }
}
