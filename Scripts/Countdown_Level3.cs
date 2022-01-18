using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Countdown_Level3 : MonoBehaviour
{
	public GameObject target;
	float currentTime = 0f;
	float startingTime = 5f;
	[SerializeField] TextMeshProUGUI countdownText;
	public static bool gameFinal = false;
	public GameObject ui;
	private PlayerController_Level3 _playerController;
	public Text endingText;

	public DataManager dataManager;
    
	private GameObject _fade;
	private FadeController _fadeController;
    // Start is called before the first frame update
    void Start()
    {
        currentTime = startingTime;
        target = GameObject.FindGameObjectWithTag("Player");
     	ui.SetActive(false);
        _playerController = target.GetComponent<PlayerController_Level3>();
        _fade = GameObject.FindGameObjectWithTag("Fade"); 
        _fadeController = _fade.GetComponent<FadeController>();
    }

    // Update is called once per frame
    void Update()
    {
	if(target.transform.position.x > 273 && _playerController.candyItems.Count == 7){
		gameFinal = true;
	}

	if (target.transform.position.x > 273 && _playerController.candyItems.Count != 7)
	{
		endingText.text = "You cannot move to the next level \n without picking all the items";
	}
	if(gameFinal == true){
		//target.active = false;
		ui.SetActive(true);
		currentTime -= 1* Time.deltaTime;
		countdownText.text = currentTime.ToString("0");
		//Time.timeScale = 0f;
		if(currentTime <= 0)
		{
			countdownText.text = "La multi ani, 2020!!!";
		}

		if (currentTime <= -5)
		{
			_playerController.enabled = false;
			ResetData();
			MoveToScene();
		}
	
	}
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
	    dataManager.Data.CandyItems = null;
	    dataManager.Data.Health = -10;
	    dataManager.Save();
    }
}
