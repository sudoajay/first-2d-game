using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float moveForce = 10f;

    [SerializeField]
    private float jumpForce = 10f;

     [SerializeField]
    private float minX , maxX;

    private Vector3 temPos;

    

    private float movementX;

    private bool isGrounded;

    private Rigidbody2D myBody;

    private SpriteRenderer sr;

    private Animator anim;

    private string WALK_ANIMATION = "Walk";

    private string GROUND_TAG = "Ground";

    private string ENEMY_TAG = "Enemy";

    public static bool isAlive = true;


    

    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();

        minX = -93.4f;
        maxX = 93.4f;

        isAlive = true;
    }

    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovementKeyword();
        AnimatePlayer();
    }

    private void FixedUpdate()
    {
        PlayerJump();
    }

    void PlayerMovementKeyword()
    {
        movementX = Input.GetAxisRaw("Horizontal");

        transform.position +=
            new Vector3(movementX, 0f, 0f) * moveForce * Time.deltaTime;


        temPos =  transform.position;
        temPos.x = transform.position.x;

        if(temPos.x < minX)
        temPos.x = minX;
        if(temPos.x > maxX)
        temPos.x = maxX;        

        transform.position = temPos;

    }

    void AnimatePlayer()
    {
        if (movementX > 0)
        {
            anim.SetBool(WALK_ANIMATION, true);
            sr.flipX = false;
        }
        else if (movementX < 0)
        {
            anim.SetBool(WALK_ANIMATION, true);
            sr.flipX = true;
        }
        else
        {
            anim.SetBool(WALK_ANIMATION, false);
        }
    }

    void PlayerJump()
    {
        if (isButtonClick() && isGrounded  )
        {
            isGrounded = false;
            myBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }

    private bool isButtonClick(){
        if(Input.GetButtonDown("Jump")) return true;
        float movementY = Input.GetAxisRaw("Vertical");
        if(movementY == 1f) return true;
        if (Input.GetMouseButtonDown(0)) return true;

        return false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(GROUND_TAG))
        {
            isGrounded = true;
        }
        if (collision.gameObject.CompareTag(ENEMY_TAG))
        {
            isAlive = false;
            Destroy(gameObject);
        }
    }


   
}
