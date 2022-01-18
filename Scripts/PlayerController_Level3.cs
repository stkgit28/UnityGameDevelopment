using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController_Level3 : MonoBehaviour
{
    public float movePower = 10f;
    public float jumpPower = 20f; 
    private int _direction = 1;

    private Rigidbody2D _rb;
    private Animator _anim;
    Vector3 _movement;
    bool _isJumping;
    private bool _alive = true;
    
    public Text scoreText;

    private static readonly int IsKickBoard = Animator.StringToHash("isKickBoard");
    private static readonly int IsRun = Animator.StringToHash("isRun");
    private static readonly int IsJump = Animator.StringToHash("isJump");
    
    public int numberPickUp;
    
    private Vector3 SpawnPoint;

    private GameObject[] gos;

    private GameObject _fade;
    private FadeController _fadeController;
    
    public List<String> candyItems;

    public DataManager dataManager;

    private Health _health;

    public GameObject endingLevel;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _health = GetComponent<Health>();
        SpawnPoint = transform.position;
        gos = GameObject.FindGameObjectsWithTag("PickUp");
        _fade = GameObject.FindGameObjectWithTag("Fade"); 
        _fadeController = _fade.GetComponent<FadeController>();
        LoadData();
        PlacePlayer();
    }

    private void FixedUpdate()
    {
        if (_alive)
        {
            Run();
        }
        
    }

    private void Update()
    {
        Restart();
        if (_alive)
        {
            Jump();
            Quit();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        _anim.SetBool(IsJump, false);
        if (other.gameObject.CompareTag("KIller"))
        {
            IsHurt();
        }
    }
    
    void Run()
    {

        Vector3 moveVelocity = Vector3.zero;
        _anim.SetBool(IsRun, false);
        
        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            _direction = -1;
            moveVelocity = Vector3.left;

            transform.localScale = new Vector3(_direction, 1, 1);
            if (!_anim.GetBool(IsJump))
                _anim.SetBool(IsRun, true);

        }
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            _direction = 1;
            moveVelocity = Vector3.right;

            transform.localScale = new Vector3(_direction, 1, 1);
            if (!_anim.GetBool(IsJump))
                _anim.SetBool(IsRun, true);

        }
        transform.position += moveVelocity * movePower * Time.deltaTime;
        
    }

    void Jump()
    {
        if ((Input.GetButtonDown("Jump") || Input.GetAxisRaw("Vertical") > 0)
            && !_anim.GetBool(IsJump))
        {
            _isJumping = true;
            _anim.SetBool(IsJump, true);
        }
        if (!_isJumping)
        {
            return;
        }

        _rb.velocity = Vector2.zero;

        Vector2 jumpVelocity = new Vector2(0, jumpPower);
        _rb.AddForce(jumpVelocity, ForceMode2D.Impulse);

        _isJumping = false;
    }


    void Quit()
    {
         if (Input.GetKeyDown(KeyCode.Q))
         {
             //SceneManager.LoadScene("Menu");
             _fadeController.FadeToLevel(1);
         }
    }
        
    void Restart()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartParts();
        }
    }
    
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        bool taked = false;
        if (collision.gameObject.CompareTag("Mucus"))
        {
            _health.TakeDamage(4);
            taked = true;
        }

        if (collision.gameObject.CompareTag("Virus"))
        {
            _health.TakeDamage(1);
            taked = true;
        }
        if (taked)
        {
            scoreText.text = "Candy collected: " + numberPickUp;
            if (_health.currentHealth < 0)
            {
                _alive = false;
                endingLevel.GetComponent<Ending_Lvl5>().ChangeText(_alive);
                //dataManager.Data.Health = 3;
                //Debug.Log(dataManager.Data.PandemicItems); 
                //dataManager.Save();
            }
            else
            {
                if (_direction == 1)
                    _rb.AddForce(new Vector2(-5f, 1f), ForceMode2D.Impulse);
                else
                    _rb.AddForce(new Vector2(5f, 1f), ForceMode2D.Impulse);
            }
        }
    }
    
    private void PlacePlayer()
    {
        if (dataManager.Data.PlayerPositionX != 0f || dataManager.Data.PlayerPositionY != 0f ||
            dataManager.Data.PlayerPositionZ != 0f)
        {
            transform.position = new Vector3(dataManager.Data.PlayerPositionX, dataManager.Data.PlayerPositionY, dataManager.Data.PlayerPositionZ);
        }
        else
        {
            transform.position = SpawnPoint;
        }
    }


    private void LoadData()
    {
        dataManager.Load();
        GetData();
        scoreText.text = "Candy collected: " + numberPickUp;
        SetHealth();
    }

    private void SetHealth()
    {
        if (dataManager.Data.Health >= 0)
        {
            _health.SetHealth(dataManager.Data.Health);

        }
        else
        {
            _health.SetHealth(3);
        }
    }

    public void SaveHealth()
    {
        dataManager.Data.Health = _health.SaveHealth();
        dataManager.Save();
    }

    private void GetData()
    {
        dataManager.Load();
        if (dataManager.Data.CandyItems != null)
        {
            candyItems = dataManager.Data.CandyItems;
            numberPickUp = candyItems.Count;
        }
        else
        {
            candyItems = null;
            numberPickUp = 0;
        }
    }


    void RestartParts()
    {
        _anim.SetBool(IsKickBoard, false);
        _anim.SetTrigger("idle");
        _alive = true;
        GetData();
        PlacePlayer();
        SetHealth();
        
        scoreText.text = "Candy collected: " + numberPickUp;
        foreach (GameObject go in gos){
            go.SetActive(true);
        }
        if (candyItems != null)
        {
            foreach (string gb in candyItems)
            {
                if (GameObject.Find(gb))
                {
                    GameObject.Find(gb).SetActive(false);
                }
            }
        }
        endingLevel.GetComponent<Countdown_Level3>().ChangeText(_alive);
    }
    
    public void IsHurt()
    {
        if (_health.currentHealth >= 0)
        {
            _health.TakeDamage(1);
            if (_direction == 1)
                _rb.AddForce(new Vector2(-5f, 1f), ForceMode2D.Impulse);
            else
                _rb.AddForce(new Vector2(5f, 1f), ForceMode2D.Impulse);
        }
        if (_health.currentHealth < 0)
        {
            _alive = false;
            endingLevel.GetComponent<Countdown_Level3>().ChangeText(_alive);
            dataManager.Data.Health = 3;
            dataManager.Save();
        }
    }
    public void death(){
            //Time.timeScale=0;
        }
    }

    
