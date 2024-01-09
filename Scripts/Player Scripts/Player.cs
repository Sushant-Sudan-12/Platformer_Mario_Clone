using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{


    public float speed = 5f;

    public Rigidbody2D mybody;
    public Animator anim;

    public Transform ground_check;
    public LayerMask GroundLayer;

    public bool isgrounded;
    public bool jumped;
    public float jumppower=5f;

    void Awake(){
        mybody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics2D.Raycast(ground_check.position,Vector2.down,0.5f,GroundLayer)){
            isgrounded = true;
        }
        checkifgrounded();
        PlayerJump();
    }
    
    // this is where we do physics calculation
    void FixedUpdate()
    {
        PlayerWalk();
    }

    void PlayerWalk(){
        float h = Input.GetAxisRaw("Horizontal");

        if (h> 0){
            mybody.velocity = new Vector2 (speed , mybody.velocity.y );
            ChangeDirection(1);

        } 
        else if (h< 0){
            mybody.velocity = new Vector2 (-speed , mybody.velocity.y );
            ChangeDirection(-1);

        } 
        else{
            mybody.velocity = new Vector2 (0,mybody.velocity.y);
        }
        anim.SetInteger("Speed",Mathf.Abs((int)mybody.velocity.x));
    } 
    
    void ChangeDirection(int directiion){
        Vector3 tempScale = transform.localScale;
        tempScale.x = directiion;
        transform.localScale = tempScale; 
    }
    
    void checkifgrounded(){
        isgrounded = Physics2D.Raycast(ground_check.position,Vector2.down,0.1f,GroundLayer);
        if(isgrounded){
            if (jumped){
                jumped = false;
                anim.SetBool("jump",false);    
            }
            
            
        }
    }

    void PlayerJump(){
        if (isgrounded){
            if(Input.GetKey(KeyCode.Space)){
                jumped = true;
                mybody.velocity = new Vector2 (mybody.velocity.x,jumppower);
                anim.SetBool("jump",true);
            }
        }
    }

    // void OnCollisionEnter2D(Collision2D target)
    // {
    //     if (target.gameObject.tag ==  "Ground"){
            
    //     }
    // }
    
    // OnTriggerEnter can also be used

} 
