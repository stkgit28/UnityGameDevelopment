using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class PickUpController : MonoBehaviour
{
    private GameObject _player;
    private StudentController _playerController;
    [FormerlySerializedAs("MyText")] public Text myText;
    private float originalY;
    public float floatStrength = 0.5f;
    public float speed = 2f;
    public DataManager dataManager;



    // Start is called before the first frame update
    void Start()
    {
        dataManager.Load();
        _player = GameObject.FindGameObjectWithTag("Player"); 
        _playerController = _player.GetComponent<StudentController>();
        originalY = transform.position.y;
        if (dataManager.Data.BooksPickup != null && dataManager.Data.BooksPickup.Contains(gameObject.name))
        {
            gameObject.SetActive (false);
        }
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
            if (_playerController.booksPickup != null)
            {
                if (!_playerController.booksPickup.Contains(gameObject.name) &&
                    (dataManager.Data.PlayerPositionX == 0f && dataManager.Data.PlayerPositionY == 0f &&
                     dataManager.Data.PlayerPositionZ == 0f))
                {
                    _playerController.booksPickup.Add(gameObject.name);
                }
            }
            else
            {
                _playerController.booksPickup.Add(gameObject.name);
            }
            gameObject.SetActive (false);
            myText.text = "Known persons: " + _playerController.cunosc + "  Items collected: "  + _playerController.numberPickUp;
        }

    }
        
}
