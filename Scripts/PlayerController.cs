using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
    {
        public float movePower = 10f;
        public float KickBoardMovePower = 25f;
        public float jumpPower = 20f; //Set Gravity Scale in Rigidbody2D Component to 5

        private Rigidbody2D rb;
        private Animator anim;
        Vector3 movement;
        private int direction = 1;
        bool isJumping = false;
        private bool alive = true;
        private bool isKickboard = false;
        
        public int numberOfBooksPickUp;
        public Text scoreText;
        private GameObject[] gos;
        private Vector3 SpawnPoint;
        
        private GameObject _fade;
        private FadeController _fadeController;
        
        private Health _health;
        public List<String> booksPickup;
        public DataManager dataManager;

        // Start is called before the first frame update
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            anim = GetComponent<Animator>();
            _health = GetComponent<Health>();
            gos = GameObject.FindGameObjectsWithTag("PickUp");
            _fade = GameObject.FindGameObjectWithTag("Fade"); 
            _fadeController = _fade.GetComponent<FadeController>();
            SpawnPoint = transform.position;
            dataManager.Load();
            PlacePlayer();
            LoadData();
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
                KickBoard();
                Quit();
            }
        } 
        private void OnTriggerEnter2D(Collider2D other)
        {
            anim.SetBool("isJump", false);
        }
        
	    private void OnCollisionStay2D(Collision2D other) {
		    if(other.gameObject.CompareTag("Trotineta")) {
                isKickboard = true;
                anim.SetBool("isKickBoard", true);
            }
	    }
        
        void KickBoard()
        {
            if (Input.GetKeyDown(KeyCode.T) && isKickboard)
            {
                GameObject.FindGameObjectWithTag("KickBoard").GetComponent<BoxCollider2D>().enabled = false;

                isKickboard = false;
                anim.SetBool("isKickBoard", false);
            }
            else if (Input.GetKeyDown(KeyCode.T) && !isKickboard )
            {
                GameObject.FindGameObjectWithTag("KickBoard").GetComponent<BoxCollider2D>().enabled = true;

                isKickboard = true;
                anim.SetBool("isKickBoard", true);
            }

        }

        void Run()
        {
            if (!isKickboard)
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
            if (isKickboard)
            {
                Vector3 moveVelocity = Vector3.zero;
                if (Input.GetAxisRaw("Horizontal") < 0)
                {
                    direction = -1;
                    moveVelocity = Vector3.left;

                    transform.localScale = new Vector3(direction, 1, 1);
                }
                if (Input.GetAxisRaw("Horizontal") > 0)
                {
                    direction = 1;
                    moveVelocity = Vector3.right;

                    transform.localScale = new Vector3(direction, 1, 1);
                }
                transform.position += moveVelocity * KickBoardMovePower * Time.deltaTime;
            }
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
        
        void Quit()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
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
    
    private void SetHealth()
    {
        if (dataManager.Data.Health > 0)
        {
            _health.SetHealth(dataManager.Data.Health);

        }
        else
        {
            _health.SetHealth(3);
        }
    }
    
    private void LoadData()
    {
        if (dataManager.Data.BooksPickup != null)
        {
            booksPickup = dataManager.Data.BooksPickup;
            numberOfBooksPickUp = booksPickup.Count;
        }
        else
        {
            booksPickup = null;
            numberOfBooksPickUp = 0;
        }
        SetHealth();
        scoreText.text = "Books collected: " + numberOfBooksPickUp;
    }

    void RestartParts()
    {
        isKickboard = false;
        anim.SetBool("isKickBoard", false);
        anim.SetTrigger("idle");
        dataManager.Load();
        if (dataManager.Data.BooksPickup != null)
        {
            booksPickup = dataManager.Data.BooksPickup;
            numberOfBooksPickUp = booksPickup.Count;
        }
        else{
            booksPickup = null;
            numberOfBooksPickUp = 0;
        }
        scoreText.text = "Books collected: " + numberOfBooksPickUp;
        PlacePlayer();
        foreach (GameObject go in gos){
            go.SetActive(true);
        }

        if (booksPickup != null)
        {
            foreach (string gb in booksPickup)
            {
                GameObject.Find(gb).SetActive(false);
            }
        }

        alive = true;
    
    }

    public void death(){
            //Time.timeScale=0;
        }
    

    }
