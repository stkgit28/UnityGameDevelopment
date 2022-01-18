using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class LevelEndingCheck : MonoBehaviour
{
    private GameObject _player;
    private StudentController _playerController;
    public Text endingText;

    public DataManager dataManager;
    
    private GameObject _fade;
    private FadeController _fadeController;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player"); 
        _playerController = _player.GetComponent<StudentController>();
        _fade = GameObject.FindGameObjectWithTag("Fade"); 
        _fadeController = _fade.GetComponent<FadeController>();
    }
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (_playerController.numberPickUp != 10 || _playerController.cunosc != 6)
        {
            endingText.text = "You cannot move to the next level \n without completing all the tasks";
        }
        else
        {
            endingText.text = "You passed the level";
            _player.GetComponent<StudentController>().enabled = false;
            ResetData();
            MoveToScene();
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        endingText.text = "  ";
    }
    
    public void MoveToScene()
    {
        _playerController.enabled = true;
        _fadeController.FadeToLevel(dataManager.Data.LevelIndex);

    }

    public void ChangeText(bool alive)
    {
        if (alive)
        {
            endingText.text = "";
        }
        else
        {
            endingText.text = "You died. Press the R key to reset the player";
        }
    }
    
    private void ResetData()
    {
        dataManager.Data.LevelIndex = SceneManager.GetActiveScene().buildIndex + 1;
        dataManager.Data.PlayerPositionX = 0f;
        dataManager.Data.PlayerPositionY = 0f;
        dataManager.Data.PlayerPositionZ = 0f;
        dataManager.Data.BooksPickup = null;
        dataManager.Data.Health = -10;
        dataManager.Save();
    }
    

}
