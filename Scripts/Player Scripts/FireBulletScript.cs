using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBulletScript : MonoBehaviour
{

    private float speed = 10f;
    private Animator anim;
    private bool canMove;
    
    void Awake()
    {
        anim = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        canMove = true;
        StartCoroutine(DisableBullet(5f));
    }

    // Update is called once per frame
    void Update()
    {
        if(canMove){
            Move();
        }
    }

    void Move(){
        Vector3 temp = transform.position;
        temp.x += speed*Time.deltaTime;
        transform.position = temp;
    }
    public float Speed{
        get{
            return speed;
        }
        set{
            speed = value;
        }
    }
    IEnumerator DisableBullet(float timer){
        yield return new WaitForSeconds(timer);
        gameObject.SetActive(false);
    }




    void OnTriggerEnter2D(Collider2D target){
        if(target.gameObject.tag == "Snail"  || target.gameObject.tag == "Beetle" || target.gameObject.tag == "Bird"){
            canMove = false;
            anim.Play("bullet_anim");
            StartCoroutine(DisableBullet(0.3f));
        }
    }

}
