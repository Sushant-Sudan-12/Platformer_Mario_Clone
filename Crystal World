using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private Rigidbody2D mybody;
    private Animator anim;

    public float jumppower = 5f;
    public float speed = 5f;
    public bool isjumping = false;
    public bool canJump = true;

    public Transform ground_check;
    public LayerMask GroundLayer;

    void Awake(){
        mybody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    
    void Start()
    {
        groundcheck();
    }

    
    void Update()
    {
        groundcheck();
        playerjump();
    }
    void FixedUpdate()
    {
        playerMove();
        if(mybody.velocity == new Vector2(0,0)){
            anim.Play("Idle");
        }
        
    }

    void playerjump(){
        if(canJump){
            if (Input.GetKeyDown(KeyCode.Space)){
                mybody.velocity = new Vector2(mybody.velocity.x,speed);
                anim.Play("Jump");
                isjumping = true;
            }
        }
    }
    void playerMove(){
        float h = Input.GetAxisRaw("Horizontal");

        if(h > 0){
            mybody.velocity = new Vector2(speed , mybody.velocity.y);
            ChangeDirection(2.5f);
            if (!isjumping){   
                anim.Play("Run");
            }
        }
        else if (h < 0 ){
            mybody.velocity = new Vector2(-speed, mybody.velocity.y);
            ChangeDirection(-2.5f);  
            if (!isjumping){   
                anim.Play("Run");
            }   
        }
    }
    void groundcheck(){
        if(Physics2D.Raycast(ground_check.position,Vector2.down,0.1f,GroundLayer)){
            isjumping = false;
            canJump = true;
        }
    }

    void ChangeDirection(float f){
        Vector3 temp = transform.localScale;
        temp.x = f;
        transform.localScale = temp;
    }
    void Playerattack(){
        if()
    }
} // end
