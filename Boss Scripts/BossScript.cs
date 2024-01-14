using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    private Rigidbody2D mybody;
    private Animator anim;
    public GameObject Boss_bone;
    public Transform top_pos;

    void Awake()
    {
        mybody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartAttack());  
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Instantiate_Stone(){
        GameObject obj = Instantiate(Boss_bone,top_pos.position,Quaternion.identity);
        obj.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-300f,-700f),0f));
        
    }

    public void EndAttack(){
        anim.Play("Idle");
        StartCoroutine(StartAttack());  

    }
    IEnumerator StartAttack(){
        yield return new WaitForSeconds(3f);
        anim.Play("Attack");
    }
}
