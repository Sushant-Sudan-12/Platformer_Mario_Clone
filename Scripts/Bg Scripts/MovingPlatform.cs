using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{

    public Transform platform;
    public Transform startPosition;
    public Transform endPosition;
    public float speed = 1.5f;
    int direction = 1;

    void Update()
    {
        Vector2 target = CheckPosition();
        platform.position = Vector2.MoveTowards(platform.position,target,speed*Time.deltaTime);

        float distance = (target - (Vector2)platform.position).magnitude;

        if (distance <= 0.1f){
            direction *= -1;
        }
    }
    Vector2 CheckPosition(){
        if (direction==1){
            return startPosition.position;
        }else{
            return endPosition.position;
        }
    }

    // void OnCollisionEnter2D(Collision2D collision)
    // {
    //     collision.transform.SetParent(transform);
    // }

    // void OnCollisionExit2D(Collision2D collision)
    // {
    //     collision.transform.SetParent(null);
    // }
}
