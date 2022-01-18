using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class CoinController_Level3 : MonoBehaviour
{
	private GameObject _player;
	private PlayerController_Level3 _playerController;
	[FormerlySerializedAs("MyText")] public Text myText;    
	public DataManager dataManager;

	void Start()
	{
		dataManager.Load();
		_player = GameObject.FindGameObjectWithTag("Player"); 
		_playerController = _player.GetComponent<PlayerController_Level3>();
		if (dataManager.Data.CandyItems != null && dataManager.Data.CandyItems.Contains(gameObject.name))
		{
			gameObject.SetActive (false);
		}
        
	}


    private void OnTriggerEnter2D(Collider2D other)
    {
	    if (gameObject.CompareTag("PickUp") && gameObject.activeSelf)
	    {
		    _playerController.numberPickUp += 1;
		    if (_playerController.candyItems != null)
		    {
			    if (!_playerController.candyItems.Contains(gameObject.name) &&
			        (dataManager.Data.PlayerPositionX == 0f && dataManager.Data.PlayerPositionY == 0f &&
			         dataManager.Data.PlayerPositionZ == 0f))
			    {
				    _playerController.candyItems.Add(gameObject.name);
			    }
		    }
		    else
		    {
			    _playerController.candyItems.Add(gameObject.name);
		    }
		    gameObject.SetActive (false);
		    myText.text = "Candy collected: " + _playerController.numberPickUp;
	    }

    }
}
