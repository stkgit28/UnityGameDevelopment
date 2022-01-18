using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController_Lvl4 : MonoBehaviour
    {
        public float movePower = 10f;
        public float jumpPower = 20f; 

        private Rigidbody2D rb;
        private Animator anim;
        Vector3 movement;
        private int direction = 1;
        bool isJumping = false;
        private bool alive = true;

        private Health _health;
        
        private GameObject _fade;
        private FadeController _fadeController;

        private Vector3 SpawnPoint;
        
        public DataManager dataManager;

        public GameObject endingLevel;

        // Start is called before the first frame update
        void Start()
        {
            _health = GetComponent<Health>();
            rb = GetComponent<Rigidbody2D>();
            anim = GetComponent<Animator>();
            SpawnPoint = transform.position;
            _fade = GameObject.FindGameObjectWithTag("Fade"); 
            _fadeController = _fade.GetComponent<FadeController>();
            LoadData();
            PlacePlayer();
        }

        private void FixedUpdate()
        {
            if (alive)
            {
                Run();
            }
        
        }

        private void Update()
        {
            Restart();
            if (alive)
            {
                Jump();
                Quit();
            }
        }
        private void OnTriggerEnter2D(Collider2D other)
        {
            anim.SetBool("isJump", false);
        }
        
        
        void Run()
        {
            Vector3 moveVelocity = Vector3.zero;
            anim.SetBool("isRun", false);


            if (Input.GetAxisRaw("Horizontal") < 0) 
            {
                    direction = -1;
                    moveVelocity = Vector3.left;

                    transform.localScale = new Vector3(direction, 1, 1);
                    if (!anim.GetBool("isJump"))
                        anim.SetBool("isRun", true);

            }
            if (Input.GetAxisRaw("Horizontal") > 0)
            {
                direction = 1;
                moveVelocity = Vector3.right;

                transform.localScale = new Vector3(direction, 1, 1); 
                if (!anim.GetBool("isJump"))
                    anim.SetBool("isRun", true);

            }
            transform.position += moveVelocity * movePower * Time.deltaTime;
        }
        void Jump()
        {
            if ((Input.GetButtonDown("Jump") || Input.GetAxisRaw("Vertical") > 0)
            && !anim.GetBool("isJump"))
            {
                isJumping = true;
                anim.SetBool("isJump", true);
            }
            if (!isJumping)
            {
                return;
            }

            rb.velocity = Vector2.zero;

            Vector2 jumpVelocity = new Vector2(0, jumpPower);
            rb.AddForce(jumpVelocity, ForceMode2D.Impulse);

            isJumping = false;
        }
        

    void Restart()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            anim.SetTrigger("idle");
            LoadData();
            PlacePlayer();
            alive = true;
            endingLevel.GetComponent<EndingLvl4>().ChangeText(alive);
        }
    }
    

    public void IsHurt()
    {
        if (_health.currentHealth >= 0)
        {
            _health.TakeDamage(1);
            if (direction == 1)
                rb.AddForce(new Vector2(-5f, 1f), ForceMode2D.Impulse);
            else
                rb.AddForce(new Vector2(5f, 1f), ForceMode2D.Impulse);
        }
        if (_health.currentHealth < 0)
        {
            alive = false;
            endingLevel.GetComponent<EndingLvl4>().ChangeText(alive);
            dataManager.Data.Health = 3;
            dataManager.Save();
        }
    }
    
    void Quit()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            _fadeController.FadeToLevel(1);
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


    public void death(){
           // Time.timeScale=0;
        }

    }
