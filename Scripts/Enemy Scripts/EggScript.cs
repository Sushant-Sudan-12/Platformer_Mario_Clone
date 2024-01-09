using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggScript : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D target){
        if(target.gameObject.tag == "Player"){
            //do damage
        }    
        gameObject.SetActive(false);
    }
    
}
