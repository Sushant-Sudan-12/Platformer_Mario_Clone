using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusBlock : MonoBehaviour
{
    public Transform bottom_collision;
    private Animator anim;
    public LayerMask playerLayer;
    private Vector3 moveDirection = Vector3.up;
    private Vector3 originPosition;
    private Vector3 animPosition;
    private bool startAnim; 

    void Awake()
    {
        anim = GetComponent<Animator>();

    }
    
    void Start()
    {
        originPosition = transform.position;
        animPosition  =  transform.position;
        animPosition.y += 0.15f;   
    }

    
    void Update()
    {
        CheckForCollision();
        AnimateUpDown();
    }

    void CheckForCollision(){
        RaycastHit2D hit = Physics2D.Raycast(bottom_collision.position,Vector2.down,0.1f,playerLayer);
        if(hit){
            if(hit.collider.gameObject.tag == "Player"){
                anim.Play("Idle");
                startAnim = true;
            }
        }
    }
    void AnimateUpDown(){
        if (startAnim){
            transform.Translate(moveDirection*Time.smoothDeltaTime);

            if(transform.position.y >= animPosition.y){
                moveDirection = Vector3.down;
            }
            else if(transform.position.y <= originPosition.y){
                startAnim = false;
            }
        }

    }
}
