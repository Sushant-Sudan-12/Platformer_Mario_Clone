using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBoneScript : MonoBehaviour
{
    void Awake(){
        
    }
    void FixedUpdate()
    {
        StartCoroutine(DestroyStone());
    }
    void OnCollisionEnter2D(Collision2D target){
        if(target.gameObject.tag == "Player"){
            target.gameObject.GetComponent<PlayerDamage>().DealDamage();
            gameObject.SetActive(false);
        }
        gameObject.SetActive(false);
    }
    IEnumerator DestroyStone(){
        yield return new WaitForSeconds(1f);
        gameObject.SetActive(false);
    }
    
}
