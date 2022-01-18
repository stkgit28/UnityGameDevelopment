using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet2Controller_niv4 : MonoBehaviour
{

    [SerializeField] private float attackSpeed = 1f;
    public float speed = 0f;
    private SpriteRenderer spriteRenderer;
    private float canAttack;
    
    private Vector3 initialPosition;
    
    public DataManager dataManager;

    void Start()
    {
	    initialPosition = transform.position;
	    spriteRenderer = GetComponent<SpriteRenderer>();
	    SetPosition();
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
    
    private void OnCollisionStay2D(Collision2D other) {
	    if(other.gameObject.CompareTag("Player")) {
		    if(attackSpeed <= canAttack){
			    other.gameObject.GetComponent<PlayerController_Lvl4>().IsHurt();
			    canAttack = 0f; 
		    } else {
			    canAttack += Time.deltaTime;
		    }
	    }
    }
    
    void ResetPosition()
    {
	    if (Input.GetKeyDown(KeyCode.R))
	    {
		    SetPosition();
	    }
    }

    void SetPosition()
    {
	    dataManager.Load();
	    if (dataManager.Data.PlayerPositionX == 0 && dataManager.Data.PlayerPositionZ == 0 &&
	        dataManager.Data.PlayerPositionY == 0)
	    {
		    transform.position = initialPosition;
	    }
	    else
	    {
		    transform.position = new Vector3(584.0f, initialPosition.y, initialPosition.z);
	    }
    }
}
