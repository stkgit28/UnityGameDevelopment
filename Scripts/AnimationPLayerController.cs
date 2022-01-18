using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationPLayerController : MonoBehaviour
{
        public float movePower = 10f;
        public float KickBoardMovePower = 15f;
        public float jumpPower = 20f; //Set Gravity Scale in Rigidbody2D Component to 5
        private float horizontalInput;
        private Rigidbody2D rb;
        private Animator anim;
         private BoxCollider2D boxCollider;
        Vector3 movement;
        private int direction = 1;
        bool isJumping = false;
        public bool alive = true;
        private bool isKickboard = false;
        private bool abilityFire;
        
        private Vector3 SpawnPoint;

        private GameObject _fade;
        private FadeController _fadeController;


        // modificare
        private LadderMovement _ladderMovement;
        // Start is called before the first frame update
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            anim = GetComponent<Animator>();
            _fade = GameObject.FindGameObjectWithTag("Fade"); 
            _fadeController = _fade.GetComponent<FadeController>();
            // modificare
            _ladderMovement = GetComponent<LadderMovement>();
            boxCollider = GetComponent<BoxCollider2D>();
            SpawnPoint = transform.position;

        }

        private void Update()
        {
            horizontalInput = Input.GetAxis("Horizontal");
            Restart();
            Quit();
            if (alive)
            {
                Jump();
                Run();
            }
        }
        private void OnTriggerEnter2D(Collider2D other)
        {
            anim.SetBool("isJump", false);
            if(other.CompareTag("Fireability")){

                abilityFire=true;

            }
            if(other.CompareTag("Ending"))
            {
                anim.SetTrigger("idle");
                anim.SetBool("isRun", false);

                alive = false;
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
            // modificare

            if ((Input.GetButtonDown("Jump") || Input.GetAxisRaw("Vertical") > 0)
            && !anim.GetBool("isJump") && !_ladderMovement.onLadder)
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
                alive = true;
                transform.position = SpawnPoint;
                anim.SetTrigger("idle");
            }
        }

       
        public bool canAttack(){
            return horizontalInput==0 && !anim.GetBool("isJump") && !_ladderMovement.onLadder&&abilityFire;
        }
        
        void Quit()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                _fadeController.FadeToLevel(1);
            }
        }

        public void death(){
            Time.timeScale=0;
        }

       
}

