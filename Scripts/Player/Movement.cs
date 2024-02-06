using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour
{
    [SerializeField] Animator anim;
    [SerializeField] float horizontalSpeed = 3000f;
    [SerializeField] float verticalThrust = 150f;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask groundLayer;

    float horizontalInput;

    bool isVerticalInput;
    bool unlockedDash;
    bool canLadder;
    public bool unlockDash{get{return unlockedDash;}}
    public float climbSpeed = 5f;

    private bool isClimbing = false;
    

    [SerializeField]bool onGround;
    public bool OnGround{get{return onGround;}}
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        LeftRightMovement();
        Jump();
        GroundCheck();
        if (isClimbing && canLadder)
        {
            Climb();
        }
    }

    private void LeftRightMovement()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        float horizontalVelocity =  horizontalInput * horizontalSpeed;
        rb.velocity = new Vector2(horizontalVelocity, rb.velocity.y);
        if(Mathf.Abs(horizontalInput)>0.2f ){
            if (onGround)
            {
                anim.Play("Stomach_Walk");
            }else {
                anim.Play("Idle");
            }
            ChangeDirection(horizontalInput/Mathf.Abs(horizontalInput));
        }else{
            anim.Play("Idle");
        }
    }
    void Climb()
    {
        // float verticalInput = Input.GetAxis("Vertical");
        // Vector3 climbMovement = new Vector3(0, verticalInput, 0) * climbSpeed * Time.deltaTime;
        // transform.Translate(climbMovement);
        
        if (Input.GetKey(KeyCode.UpArrow)||Input.GetKey(KeyCode.W)){
                rb.velocity = new Vector2(rb.velocity.x,climbSpeed);
            }else if(Input.GetKey(KeyCode.DownArrow)||Input.GetKey(KeyCode.S)){
                rb.velocity = new Vector2(rb.velocity.x,-climbSpeed);
            }

    }
    private void Jump()
    {
        isVerticalInput = Input.GetButtonDown("Jump");
        if (isVerticalInput && onGround)
        {
            float forceY =  verticalThrust;
            rb.AddForce(new Vector2(0, forceY));
        }
    }

    void GroundCheck(){
        if(Physics2D.OverlapCircle(groundCheck.position,0.2f,groundLayer)){  //Physics2D.Raycast(groundCheck.position,Vector2.down,0.1f,groundLayer 
            onGround = true;
        }else{
            onGround = false;
        }

    }
    public void ChangeDirection(float set){
        Vector3 tempScale = transform.localScale ;
        tempScale.x = set;
        transform.localScale = tempScale;

    }
    void OnTriggerEnter2D(Collider2D target){
        if(target.tag == "torso"){
            unlockedDash = true;
        }else if (target.tag == "Weapon"){
            transform.DOScale(Vector2.one * 1.2f, 0.2f).SetEase(Ease.OutElastic);
            transform.DOScale(Vector2.one, 0.2f).SetDelay(0.2f);
            rb.GetComponent<PlayerDamage>().DealDamage();
        }
        else if (target.gameObject.CompareTag("Ladder"))
        {
            print("nice");
            isClimbing = true;
        }else if(target.tag == "torso2"){
            canLadder = true;
        }
    }
        
    void OnTriggerExit2D(Collider2D target)
    {
        if (target.gameObject.CompareTag("Ladder"))
        {
            print("nicer");
            isClimbing = false;
        }
    }
}
