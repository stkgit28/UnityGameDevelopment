using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Checkpoint : MonoBehaviour
{
    public TextMeshProUGUI textCheckpoint;
    public DataManager dataManager;
    private GameObject _player;
    private PlayerController _playerController;
    private StudentController _studentController;
    private PlayerController_Lvl4 _playerControllerLvl4;
    private PlayerController_Lvl5 _playerControllerLvl5;
    private PlayerController_Level3 _playerControllerLvl3;
    private bool trigger = false;
    
    void Start()
    {
        dataManager.Load();
        _player = GameObject.FindGameObjectWithTag("Player");
        LoadControllers();
        if (dataManager.Data.PlayerPositionX != 0 || dataManager.Data.PlayerPositionZ != 0 ||
            dataManager.Data.PlayerPositionY != 0)
        {
            textCheckpoint.text = "Game was saved";
        }
        else
        {
            textCheckpoint.text = "Press C to save game";
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C) && trigger)
        {
            dataManager.Data.PlayerPositionX = _player.transform.position.x;
            dataManager.Data.PlayerPositionY = _player.transform.position.y;
            dataManager.Data.PlayerPositionZ = _player.transform.position.z;
            MakeCheck();
            dataManager.Save();
            textCheckpoint.text = "Game was saved";
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (textCheckpoint.text == "Press C to save game")
        {
            
            trigger = true;
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        trigger = false;
    }

    private void LoadControllers()
    {
        if (dataManager.Data.LevelIndex <= 2)
        {
            _playerController = _player.GetComponent<PlayerController>();
        }
        else
        {
            if (dataManager.Data.LevelIndex == 3)
            {
                _studentController = _player.GetComponent<StudentController>();

            }
            else
            {
                if (dataManager.Data.LevelIndex == 5)
                {
                    _playerControllerLvl4 = _player.GetComponent<PlayerController_Lvl4>();

                }
                else
                {
                    if (dataManager.Data.LevelIndex == 6)
                    {
                        _playerControllerLvl5 = _player.GetComponent<PlayerController_Lvl5>();

                    }
                    else
                    {
                        if (dataManager.Data.LevelIndex == 4)
                        {
                            _playerControllerLvl3 = _player.GetComponent<PlayerController_Level3>();

                        }
                    }
                }
            }
        }
    }
    


    private void MakeCheck()
    {
        if (dataManager.Data.LevelIndex <= 2)
        {
            Debug.Log(_playerController.booksPickup);
            dataManager.Data.BooksPickup = _playerController.booksPickup;
        }
        else
        {
            if (dataManager.Data.LevelIndex == 3)
            {
                dataManager.Data.PeopleKnown = _studentController.peopleKnown;
                dataManager.Data.BooksPickup = _studentController.booksPickup;
                _studentController.SaveHealth();
            }
            else
            {
                if (dataManager.Data.LevelIndex == 5)
                {
                    _playerControllerLvl4.SaveHealth();
                }
                else
                {
                    if (dataManager.Data.LevelIndex == 6)
                    {
                        dataManager.Data.PandemicItems = _playerControllerLvl5.pandemicItems;
                        _playerControllerLvl5.SaveHealth();
                    }
                    else if (dataManager.Data.LevelIndex == 4)
                    {
                        dataManager.Data.CandyItems = _playerControllerLvl3.candyItems;
                        _playerControllerLvl3.SaveHealth();
                    }
                }
            }
   
        }
    }
}
