using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForth_niv4 : MonoBehaviour
{
    public float speed = 15f;
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
        moveLeft();
        ResetPosition();
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
