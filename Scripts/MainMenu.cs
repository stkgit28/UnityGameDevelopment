using System;
using System.Collections;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public DataManager dataManager;
    private GameObject _fade;
    private FadeController _fadeController;
    
    void Start()
    {
        _fade = GameObject.FindGameObjectWithTag("Fade"); 
        _fadeController = _fade.GetComponent<FadeController>();
    }
    
    public void PlayGame()
    {
        dataManager.Load();
        if (dataManager.Data.LevelIndex == -1)
        {
            _fadeController.FadeToLevel(SceneManager.GetActiveScene().buildIndex + 2);
        }
        else
        {
            _fadeController.FadeToLevel(dataManager.Data.LevelIndex);
            //SceneManager.LoadScene(dataManager.Data.LevelIndex);
        }
    }

    public void QuitGame()
    {
        Debug.Log("Game was quited!");
        Application.Quit();
    }
    

}
