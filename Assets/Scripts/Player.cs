using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField]
    private float moveForce = 2f;
    [SerializeField]
    private float jumpForce = 11f;

    private float movementX;
    
    [SerializeField]
    private Rigidbody2D myBody;

    private bool isGrounded = true;




    [SerializeField]
    private Animator anim;

    private string WALK_ANIMATION = "Walk";

[SerializeField]
    private SpriteRenderer sr;

    



   private void Awake(){
    myBody = GetComponent<Rigidbody2D>();
    anim = GetComponent<Animator>();
    sr = GetComponent<SpriteRenderer>();

   }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerKeyword();
        AnimatePlayer();
        PlayerJump();

    }

    void PlayerKeyword(){
        movementX = Input.GetAxis("Horizontal");

        // Debug.Log("Move X value is :" + movementX );
        transform.position += new Vector3(movementX, 0f, 0f) * Time.deltaTime * moveForce;


    }

    void AnimatePlayer(){
        if(movementX > 0){
            anim.SetBool(WALK_ANIMATION, true);
            sr.flipX = false;
        }
        else if (movementX < 0) {
             anim.SetBool(WALK_ANIMATION, true);
             sr.flipX = true;
        }
        else {
             anim.SetBool(WALK_ANIMATION, false);
        }
    }

    void PlayerJump(){
        if(Input.GetButtonDown("Jump") && isGrounded){

            isGrounded = false;

            Debug.Log("Jump Pressed");
            myBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
    if (other.gameObject.CompareTag("Ground")) {
        isGrounded = true;
        Debug.Log("We Landed on Ground");
    }
    else if (other.gameObject.CompareTag("Enemy")){
        Destroy(gameObject);
    }
    }
}
