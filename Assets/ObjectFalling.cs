using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFalling : MonoBehaviour
{

     public float fallSpeed = 5.0f;

        //Variables for starting position and length until reset
        private Vector3 _startingPos;
	private float _startingPosY = 5.86f;
        public float FallDistance = 2f;

        void Start()
        {
            transform.Translate(Vector3.down * fallSpeed * Time.deltaTime, Space.World);
            // Save starting position
            _startingPos = transform.position;
	    Debug.Log(transform.position);
	    Debug.Log(_startingPos);
        }

        void Update()
        {
            transform.Translate(Vector3.down * fallSpeed * Time.deltaTime, Space.World);

            // If the object has fallen longer than 
            // Starting height + FallDistance from its start position
            if (transform.position.y < -10.0f) {
                transform.position = _startingPos;
            }
        }
}
