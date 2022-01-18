using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class PickUp : MonoBehaviour
{
    private GameObject _player;
    private PlayerController _playerController;
    [FormerlySerializedAs("MyText")] public Text myText;    
    public DataManager dataManager;

    void Start()
    {
        dataManager.Load();
        _player = GameObject.FindGameObjectWithTag("Player"); 
        _playerController = _player.GetComponent<PlayerController>();
        if (dataManager.Data.BooksPickup != null && dataManager.Data.BooksPickup.Contains(gameObject.name))
        {
            gameObject.SetActive (false);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (gameObject.CompareTag("PickUp") && gameObject.activeSelf)
        {
            _playerController.numberOfBooksPickUp += 1;
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
            myText.text = "Books collected: " + _playerController.numberOfBooksPickUp;
        }

    }
}
