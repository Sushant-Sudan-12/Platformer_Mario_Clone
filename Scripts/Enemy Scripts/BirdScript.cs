 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{


    private Rigidbody2D mybody;
    private Animator anim;
    private Vector3 moveDirection = Vector3.left;
    private Vector3 originalPosition;
    private Vector3 movePosition;

    public GameObject BirdEgg;
    public LayerMask playerLayer;
    private bool attacked;
    private bool canMove;

    void Awake()
    {
        mybody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        originalPosition = transform.position;
        originalPosition.x +=6;

        movePosition = transform.position;
        movePosition.x -= 6;

        canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        moveBird();
        DropTheEgg();

    }

    void moveBird(){
        if(canMove){
            transform.Translate(moveDirection*3f*Time.deltaTime);
            if(transform.position.x >= originalPosition.x){
                moveDirection = Vector3.left;
                ChangeDirection(0.5f);
            }
            else if(transform.position.x <= movePosition.x){
                moveDirection = Vector3.right;
                ChangeDirection(-0.5f);
            }
        }
    }
    void ChangeDirection(float x){
        Vector3 temp = transform.localScale;
        temp.x = x;
        transform.localScale = temp;
    }
    void DropTheEgg(){
        if(!attacked){
            if(Physics2D.Raycast(transform.position,Vector2.down,Mathf.Infinity,playerLayer)){
                Instantiate(BirdEgg,new Vector3(transform.position.x,transform.position.y-1,transform.position.z),Quaternion.identity);
                attacked = true;
                anim.Play("BirdFly");
            }
        }
    }

    IEnumerator BirdDead(){
        yield return new WaitForSeconds(2f);
        gameObject.SetActive(false); 
    }

    void OnTriggerEnter2D(Collider2D target){
        if (target.tag == "bullet"){
            anim.Play("BirdDead");

            GetComponent<BoxCollider2D>().isTrigger = true;
            mybody.bodyType = RigidbodyType2D.Dynamic;

            canMove = false;
            
            StartCoroutine(BirdDead());
        }
        
    }
}
