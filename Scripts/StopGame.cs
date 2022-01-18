using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StopGame : MonoBehaviour
{
    public DataManager dataManager;

    private GameObject _player;
    private PlayerController _playerController;
    public Text endingText;

    private GameObject _fade;
    private FadeController _fadeController;
    void Start()
    {        
        dataManager.Load();
        _player = GameObject.FindGameObjectWithTag("Player"); 
        _playerController = _player.GetComponent<PlayerController>();
        _fade = GameObject.FindGameObjectWithTag("Fade"); 
        _fadeController = _fade.GetComponent<FadeController>();
    }
    private void OnTriggerEnter2D(Collider2D collision){
        
        if (_playerController.numberOfBooksPickUp != 3)
        {
            endingText.text = "You cannot move to the next level \n without collecting all the books";
        }
        else
        {
            endingText.text = "You passed the level";
            _player.GetComponent<PlayerController>().enabled = false;
            ResetData();
            MoveToScene();
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        endingText.text = "  ";
    }
    
    private void MoveToScene()
    {
        _playerController.enabled = true;
        _fadeController.FadeToLevel(dataManager.Data.LevelIndex);
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
