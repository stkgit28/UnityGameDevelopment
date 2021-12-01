using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float movePower = 10f;
    public float jumpPower = 20f; 
    private int direction = 1;

    private Rigidbody2D _rb;
    private Animator _anim;
    Vector3 _movement;
    private int _direction = 1;
    bool _isJumping;
    private bool _alive = true;
    private Rigidbody2D _mRigidbody;

    
    public int cunosc;
    public int lives = 3;
    public Text scoreText;
    private GameObject[] _cunoscc;
    
    
    private static readonly int Attack1 = Animator.StringToHash("attack");
    private static readonly int Die1 = Animator.StringToHash("die");
    private static readonly int IsKickBoard = Animator.StringToHash("isKickBoard");
    private static readonly int IsRun = Animator.StringToHash("isRun");
    private static readonly int Hurt1 = Animator.StringToHash("hurt");
    private static readonly int IsJump = Animator.StringToHash("isJump");


    public int numberPickUp = 0;
    
    private Vector3 SpawnPoint;


    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        cunosc = 0;
        scoreText.text = "Lives: " + lives + "  Known persons: " + cunosc + "  Items collected: " + numberPickUp;
        _mRigidbody = GetComponent<Rigidbody2D>();
        SpawnPoint = transform.position;

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
            Hurt();
            Die();
            Attack();
            Jump();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        _anim.SetBool(IsJump, false);
    }
    
    void Run()
    {

        Vector3 moveVelocity = Vector3.zero;
        _anim.SetBool(IsRun, false);
        
        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            direction = -1;
            moveVelocity = Vector3.left;

            transform.localScale = new Vector3(direction, 1, 1);
            if (!_anim.GetBool(IsJump))
                _anim.SetBool(IsRun, true);

        }
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            direction = 1;
            moveVelocity = Vector3.right;

            transform.localScale = new Vector3(direction, 1, 1);
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
    void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            _anim.SetTrigger(Attack1);
        }
    }
    void Hurt()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            _anim.SetTrigger(Hurt1);
            if (_direction == 1)
                _rb.AddForce(new Vector2(-5f, 1f), ForceMode2D.Impulse);
            else
                _rb.AddForce(new Vector2(5f, 1f), ForceMode2D.Impulse);
        }
    }
    
    void Die()
    {
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            _anim.SetBool(IsKickBoard, false);
            _anim.SetTrigger(Die1);
            _alive = false;
        }
    }
        
    void Restart()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            _anim.SetBool(IsKickBoard, false);
            _anim.SetTrigger("idle");
            _alive = true;
            lives = 3;
            cunosc = 0;
            _cunoscc = GameObject.FindGameObjectsWithTag("Cunosc");
            foreach (GameObject c in _cunoscc)
                c.transform.tag = "NuCunosc";
            scoreText.text = "Lives: " + lives + "  Known persons: " + cunosc + "  Items collected: " + numberPickUp;;
            transform.position = SpawnPoint;

        }
    }
    
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            lives--;
            scoreText.text = "Lives: " + lives + "  Known persons: " + cunosc + "  Items collected: " + numberPickUp;
            _anim.SetTrigger(Hurt1);
            if (_direction == 1)
                _rb.AddForce(new Vector2(-5f, 1f), ForceMode2D.Impulse);
            else
                _rb.AddForce(new Vector2(5f, 1f), ForceMode2D.Impulse);
            if ( lives == -1)
            {
                _anim.SetBool(IsKickBoard, false);
                _anim.SetTrigger(Die1);
                _alive = false;
                scoreText.text ="You died. Press the 0 key to reset the player.";
            }
        }
        if (collision.gameObject.CompareTag("NuCunosc"))
        {
            cunosc++;
            // SetCountText();
          
            scoreText.text = "Lives: " + lives + "  Known persons: " + cunosc + "  Items collected: " + numberPickUp;
            collision.gameObject.transform.tag = "Cunosc";
            //print("Cunostinta!");
            if ( cunosc == 4)
                scoreText.text = "Lives: " + lives + "  Known persons: " + cunosc + "    You met all your colleagues";
        }

    }
}