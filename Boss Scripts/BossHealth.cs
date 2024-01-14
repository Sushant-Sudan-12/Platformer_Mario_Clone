using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public int lifecount = 10;
    private Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D target){
        if(target.gameObject.tag == "bullet"){
            lifecount -- ;

            if (lifecount == 0){
                anim.Play("Die");
            }
        }
    }
}
