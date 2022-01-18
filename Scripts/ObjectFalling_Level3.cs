using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFalling_Level3 : MonoBehaviour
{

     public float fallSpeed = 5.0f;

        //Variables for starting position and length until reset
        private Vector3 _startingPos;
	private float _startingPosY = 5.86f;
        public float FallDistance = 2f;
	private bool CanFall;
	public float TimeBeforeFall = 1;

        void Start()
        {
      		StartCoroutine(ReadyToFall());
        }

        void Update(){
	    if(CanFall == true)
     	    {
		    transform.Translate(Vector3.down * fallSpeed * Time.deltaTime, Space.World);
		    if (transform.position.y < -5.0f) {
			transform.position = _startingPos;
		    }
	    }
		
        }

	 IEnumerator ReadyToFall ()
	 {
	     CanFall = false;
	     yield return new WaitForSeconds(TimeBeforeFall);
            _startingPos = transform.position;
	     CanFall = true;
	 }
}
