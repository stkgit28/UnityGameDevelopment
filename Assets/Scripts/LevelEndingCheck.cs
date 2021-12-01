using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelEndingCheck : MonoBehaviour
{
    private GameObject _player;
    private PlayerController _playerController;
    public Text endingText;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player"); 
        _playerController = _player.GetComponent<PlayerController>();
    }
    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (_playerController.numberPickUp != 10 || _playerController.cunosc != 4)
        {
            endingText.text = "You cannot move to the next level \n without completing all the tasks";
        }
        else
        {
            endingText.text = "You passed the level";
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        endingText.text = "  ";
    }

    

}
