using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class CameraController : MonoBehaviour
{
        
    [SerializeField] private Transform player;

    [SerializeField] private float aheadDistance;

 
    [SerializeField] private float cameraSpeed;

    private float lookAhead;

    private float lookDown;
    private float time;
    


    private void Update() {
        time+=Time.deltaTime;
        transform.position=new Vector3(player.position.x+lookAhead,player.position.y+4+lookDown,transform.position.z);
        lookAhead= Mathf.Lerp(lookAhead,(aheadDistance*player.localScale.x),Time.deltaTime*cameraSpeed);

        if (Input.GetKeyDown(KeyCode.S)|| Input.GetKeyDown(KeyCode.DownArrow)){
            lookDown-=6;
            
        }

        if(time>1.5){
            lookDown=0;
            time=0;
        }

        
    }
        

}
