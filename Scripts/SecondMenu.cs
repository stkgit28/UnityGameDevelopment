using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SecondMenu : MonoBehaviour
{
    public DataManager dataManager;
    private GameObject _fade;
    private FadeController _fadeController;

    void Start()
    {
        dataManager.Load();
        _fade = GameObject.FindGameObjectWithTag("Fade"); 
        _fadeController = _fade.GetComponent<FadeController>();
    }
    
    public void PlayGame()
    {
        dataManager.Load();

        if (dataManager.Data.LevelIndex == -1)
        {
            _fadeController.FadeToLevel(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            _fadeController.FadeToLevel(dataManager.Data.LevelIndex);
        }
    }
    
    public void ResetLevel()
    {
        dataManager.Data.PlayerPositionX = 0;
        dataManager.Data.PlayerPositionY = 0;
        dataManager.Data.PlayerPositionZ = 0;
        dataManager.Data.BooksPickup = null;
        dataManager.Data.PeopleKnown = null;
        dataManager.Data.Health = -10;
        dataManager.Data.PandemicItems = null;
        dataManager.Save();
        PlayGame();
    }

    public void QuitGame()
    {
        _fadeController.FadeToLevel(0);
    }
    
}
