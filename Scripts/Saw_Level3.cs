using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw_Level3 : MonoBehaviour
{

	public GameObject target;
	public float rotateSpeed = 5;
	public float fallSpeed = 4.0f;

        //Variables for starting position and length until reset
	private Vector3 _startingPos;
	private bool CanFall;
	public float TimeBeforeFall = 1;
	private float dist;

	void Start()
	{
	     CanFall = false;
	     _startingPos = transform.position;
        target = GameObject.FindGameObjectWithTag("Player");
	}

	void Update(){
		transform.Rotate(0,0,rotateSpeed);

		dist = transform.position.x - target.transform.position.x;
		if(dist<30){
			CanFall = true;
		} 
		if(CanFall == true)
		{
		    transform.Translate(Vector3.left * fallSpeed * Time.deltaTime, Space.World);
	    }
		
	}
	
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			other.gameObject.GetComponent<PlayerController_Level3>().IsHurt();
		}
	}

}
