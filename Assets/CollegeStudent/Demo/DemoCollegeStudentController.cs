using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ClearSky
{
    public class DemoCollegeStudentController : MonoBehaviour
    {
        public float movePower = 10f;
        public float KickBoardMovePower = 15f;
        public float jumpPower = 20f; //Set Gravity Scale in Rigidbody2D Component to 5

        private Rigidbody2D rb;
        private Animator anim;
        Vector3 movement;
        private int direction = 1;
        bool isJumping = false;
        public int cunosc;
        public int lifes = 3;
        private bool alive = true;
        private bool isKickboard = false;
        [SerializeField] private Text _scoreText;
        private GameObject[] cunoscc;
        // private int _score;
        // public GUIText countText;
        public GameObject myGameObject;


        // Start is called before the first frame update
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            anim = GetComponent<Animator>();
            cunosc = 0;
           // _scoreText.text = GetComponent<Text>();
            _scoreText.text ="Vieti: " + lifes.ToString() + "  Cunostinte: " + cunosc.ToString();
            //SetCountText();
        }

        private void Update()
        {
            Restart();
            if (alive)
            {
                Hurt();
                Die();
                Attack();
                Jump();
                KickBoard();
                Run();

            }
        }
        private void OnTriggerEnter2D(Collider2D other)
        {
            anim.SetBool("isJump", false);
        }
        void KickBoard()
        {
            if (Input.GetKeyDown(KeyCode.Alpha4) && isKickboard)
            {
                isKickboard = false;
                anim.SetBool("isKickBoard", false);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha4) && !isKickboard )
            {
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
            jumpPower = 20f;
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


        void Attack()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                anim.SetTrigger("attack");
            }
        }
        void Hurt()
        {
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                anim.SetTrigger("hurt");
                if (direction == 1)
                    rb.AddForce(new Vector2(-5f, 1f), ForceMode2D.Impulse);
                else
                    rb.AddForce(new Vector2(5f, 1f), ForceMode2D.Impulse);
            }
        }
        void Die()
        {
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                isKickboard = false;
                anim.SetBool("isKickBoard", false);
                anim.SetTrigger("die");
                alive = false;
            }
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Enemy")
            {
                lifes--;
                _scoreText.text = "Vieti: " + lifes.ToString() + "  Cunostinte: " + cunosc.ToString();
                anim.SetTrigger("hurt");
                if (direction == 1)
                    rb.AddForce(new Vector2(-5f, 1f), ForceMode2D.Impulse);
                else
                    rb.AddForce(new Vector2(5f, 1f), ForceMode2D.Impulse);
                if ( lifes == -1)
                {
                    isKickboard = false;
                    anim.SetBool("isKickBoard", false);
                    anim.SetTrigger("die");
                    alive = false;
                    _scoreText.text ="Ai murit. Apasa tasta 0 pentru a reseta player-ul.";
                }
            }
            if (collision.gameObject.tag == "NuCunosc")
            {
                cunosc++;
                // SetCountText();
          
                _scoreText.text = "Vieti: " + lifes.ToString() + "  Cunostinte: " + cunosc.ToString();
                collision.gameObject.transform.tag = "Cunosc";
                //print("Cunostinta!");
                if ( cunosc == 4)
                    _scoreText.text = "Vieti: " + lifes.ToString() + "  Cunostinte: " + cunosc.ToString() + "    Ai cunoscut toti colegii";


            }

        }

       /* void JumpH(Collision2D collision)
        {
           
            if (collision.gameObject.tag == "Jump")
            {
                jumpPower = 80f;
                isJumping = true;
                anim.SetBool("isJump", true);
                rb.velocity = Vector2.zero;

                Vector2 jumpVelocity = new Vector2(0, jumpPower);
                rb.AddForce(jumpVelocity, ForceMode2D.Impulse);

                isJumping = false;
            }
           
        }*/

        //void SetCountText()
        //{
        //  countText.text = "Count: " + cunosc.ToString();

        //}

        void Restart()
        {
            if (Input.GetKeyDown(KeyCode.Alpha0))
            {
                isKickboard = false;
                anim.SetBool("isKickBoard", false);
                anim.SetTrigger("idle");
                alive = true;
                lifes = 3;
                cunosc = 0;
                cunoscc = GameObject.FindGameObjectsWithTag("Cunosc");
                foreach (GameObject c in cunoscc)
                    c.transform.tag = "NuCunosc";
                _scoreText.text = "Vieti: " + lifes.ToString() + "  Cunostinte: " + cunosc.ToString();
                
            }
        }

    }

}