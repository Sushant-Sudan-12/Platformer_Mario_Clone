using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnailScript : MonoBehaviour
{

    public float movespeed = 3f;

    private Rigidbody2D mybody;
    private Animator anim;
    public bool isleft;
    public LayerMask playerLayer;
    private bool stunned = false;
    public bool canMove = true;

    public Transform down_collision,top_collison,left_collision,right_collision;
    private Vector3 left_collision_pos,right_collision_pos;


    void Awake()
    {
        mybody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        
        left_collision_pos = left_collision.localPosition;      // I have to change set the collision game object to not move with the player
        right_collision_pos = right_collision.localPosition;

        
    }

    // Start is called before the first frame update
    void Start()
    {
        isleft = true;
        canMove = true;

    }

    // Update is called once per frame
    void Update()
    {
        if(canMove){
            if (isleft){
                mybody.velocity = new Vector2(-movespeed,mybody.velocity.y);
                
            }
            else{
                mybody.velocity = new Vector2(movespeed,mybody.velocity.y);
            }
        }
        
        check_collision();
    }
    
    void check_collision(){

        RaycastHit2D leftHit = Physics2D.Raycast(left_collision.position,Vector2.left,0.1f,playerLayer);
        RaycastHit2D rightHit = Physics2D.Raycast(right_collision.position,Vector2.right,0.1f,playerLayer);

        Collider2D topHit =Physics2D.OverlapCircle(top_collison.position,0.2f,playerLayer);

        if (topHit!=null){
            if (topHit.gameObject.tag == "Player"){
                if (!stunned){
                    topHit.gameObject.GetComponent<Rigidbody2D>().velocity= new Vector2(topHit.gameObject.GetComponent<Rigidbody2D>().velocity.x,8f);
                    stunned= true;
                    anim.Play("Stunned");
                    mybody.velocity = new Vector2 (0,0);
                    canMove = false;
                }

                if (tag == "Beetle"){
                    StartCoroutine (Dead(0.5f));
                }
        }
        }
        if (leftHit){
            if (leftHit.collider.gameObject.tag == "Player"){
                if(!stunned){
                    
                }
                else{
                    if(tag!= "Beetle"){
                        mybody.velocity = new Vector2 (15f , mybody.velocity.y);
                        StartCoroutine(Dead(3f));
                    }
                }
            }
        }   
        if (rightHit){
            if (rightHit.collider.gameObject.tag == "Player"){
                if(!stunned){
                    //do damage
                }
                else{
                    if(tag!="Beetle"){
                        mybody.velocity = new Vector2(-15f,mybody.velocity.y);
                        StartCoroutine(Dead(3f));
                    }
                }
            }
        }  


        if (! Physics2D.Raycast(down_collision.position,Vector2.down,0.1f)){
            ChangeDirection();
        }

    }


    void ChangeDirection(){

        isleft = !isleft;

        Vector3 tempScale = transform.localScale;
        if (isleft){
            tempScale.x = Mathf.Abs(tempScale.x);

            left_collision.localPosition = left_collision_pos;
            right_collision.localPosition = right_collision_pos;

        }
        else{
            tempScale.x = -Mathf.Abs(tempScale.x); 

            left_collision.localPosition = right_collision_pos;
            right_collision.localPosition = left_collision_pos;
        }
        transform.localScale = tempScale;
    }
    IEnumerator Dead(float Timer){
        yield return new WaitForSeconds(Timer);
        gameObject.SetActive(false);
    }
    void OnTriggerEnter2D(Collider2D target){
        if(target.tag == "bullet"){
            if(tag == "Snail"){
                if(!stunned){
                    canMove = false;
                    anim.Play("Stunned");
                    stunned = true;
                    mybody.velocity = new Vector2(0,0);
                }else{
                    gameObject.SetActive(false);
                }
            }
            else if(tag == "Beetle"){
                canMove = false;
                anim.Play("Stunned");
                StartCoroutine(Dead(0.4f));
            }
        }
    }
}
