using UnityEngine;

public class ObjectFalling : MonoBehaviour
{

     public float fallSpeed = 5.0f;

        //Variables for starting position and length until reset
        private Vector3 _startingPos;

        void Start()
        {
            transform.Translate(Vector3.down * fallSpeed * Time.deltaTime, Space.World);
            // Save starting position
            _startingPos = transform.position;
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
