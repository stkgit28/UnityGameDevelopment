using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class PickUpController : MonoBehaviour
{
    private GameObject _player;
    private PlayerController _playerController;
    [FormerlySerializedAs("MyText")] public Text myText;
    private float originalY;
    public float floatStrength = 0.5f;
    public float speed = 2f;


    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player"); 
        _playerController = _player.GetComponent<PlayerController>();
        originalY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x,  originalY + ((float)Math.Sin(Time.time*speed) * 
                                                                             floatStrength), transform.position.z);
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (gameObject.CompareTag("PickUp") && gameObject.activeSelf)
        {
            _playerController.numberPickUp += 1;
            //Debug.Log(playerController.numberPickUp);

        }
        gameObject.SetActive (false);
        myText.text = "Lives: " + _playerController.lives + "  Known persons: " + _playerController.cunosc + "  Items collected: "  + _playerController.numberPickUp;
    }
        
}
