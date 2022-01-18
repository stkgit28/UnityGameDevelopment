using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableFire : MonoBehaviour
{
   

    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("Player")){

            transform.GetChild(0).gameObject.SetActive(false);

        }
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            transform.GetChild(0).gameObject.SetActive(true);
        }
    }


}
