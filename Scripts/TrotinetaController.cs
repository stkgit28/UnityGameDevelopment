using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrotinetaController : MonoBehaviour
{
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
		Destroy(gameObject);
	}
    }
}
