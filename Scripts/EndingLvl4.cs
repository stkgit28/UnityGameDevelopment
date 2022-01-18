using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndingLvl4 : MonoBehaviour
{
    private GameObject _player;
    private PlayerController_Lvl4 _playerController;
    public Text endingText;

    public DataManager dataManager;
    
    private GameObject _fade;
    private FadeController _fadeController;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player"); 
        _playerController = _player.GetComponent<PlayerController_Lvl4>();
        _fade = GameObject.FindGameObjectWithTag("Fade"); 
        _fadeController = _fade.GetComponent<FadeController>();
    }
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        endingText.text = "You passed the level";
        _player.GetComponent<PlayerController_Lvl4>().enabled = false;
        ResetData();
        MoveToScene();
        
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
        dataManager.Data.PandemicItems = null;
        dataManager.Data.Health = -10;
        dataManager.Save();
    }
}
