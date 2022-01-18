using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_Level3 : MonoBehaviour
{
    private Vector3 _startingPos;

    public GameObject omZapada;
    public GameObject target;

    public float speed = 6f;
    private float omZapadaX;
    private float targetX;
    private float playerY;

    private float dist;
    private float nextX;
    private float baseY;
    private float height;

    // Start is called before the first frame update
    void Start()
    {
        omZapada = GameObject.FindGameObjectWithTag("OmZapada");
        target = GameObject.FindGameObjectWithTag("Player");
	_startingPos = transform.position;
	playerY = target.transform.position.y;

    }

    // Update is called once per frame
    void Update()
    {
        omZapadaX = omZapada.transform.position.x;
        targetX = target.transform.position.x;

		dist = targetX - omZapadaX;
		if((dist < -8 && dist > - 30)|| (dist < 30 && dist > 8)){
			nextX = Mathf.MoveTowards(transform.position.x,targetX, speed * Time.deltaTime);
			baseY = Mathf.Lerp(omZapada.transform.position.y, playerY, (nextX - omZapadaX) / dist);

			Vector3 movePosition = new Vector3(nextX, baseY, transform.position.z);
			transform.rotation = LookAtTarget(movePosition - transform.position);
			transform.position = movePosition;
			

			if((transform.position.x == target.transform.position.x) && (transform.position.y == playerY)){
				transform.position = _startingPos;

			}
		}
		else {
			transform.position = _startingPos;
		}


    }

    private static Quaternion LookAtTarget(Vector2 rotation){
		return Quaternion.Euler(0,0, Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg);
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
	    if (other.gameObject.CompareTag("Player"))
	    {
		    other.gameObject.GetComponent<PlayerController_Level3>().IsHurt();
	    }
    }
}
