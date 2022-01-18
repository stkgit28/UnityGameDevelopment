using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class PickUp_Lvl5 : MonoBehaviour
{
    private GameObject _player;
    private PlayerController_Lvl5 _playerController;
    [FormerlySerializedAs("MyText")] public Text myText;
    public DataManager dataManager;



    // Start is called before the first frame update
    void Start()
    {
        dataManager.Load();
        _player = GameObject.FindGameObjectWithTag("Player"); 
        _playerController = _player.GetComponent<PlayerController_Lvl5>();
        if (dataManager.Data.PandemicItems != null && dataManager.Data.PandemicItems.Contains(gameObject.name))
        {
            gameObject.SetActive (false);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (gameObject.CompareTag("PickUp") && gameObject.activeSelf)
        {
            _playerController.numberPickUp += 1;
            if (_playerController.pandemicItems != null)
            {
                if (!_playerController.pandemicItems.Contains(gameObject.name) &&
                    (dataManager.Data.PlayerPositionX == 0f && dataManager.Data.PlayerPositionY == 0f &&
                     dataManager.Data.PlayerPositionZ == 0f))
                {
                    _playerController.pandemicItems.Add(gameObject.name);
                }
            }
            else
            {
                _playerController.pandemicItems.Add(gameObject.name);
            }
            gameObject.SetActive (false);
            myText.text = "Items collected: "  + _playerController.numberPickUp;
        }

    }
        
}
