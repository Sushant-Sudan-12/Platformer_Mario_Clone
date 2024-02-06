using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTouchMovement : MonoBehaviour
{

    public Transform platform;
    public Transform startPosition;
    public Transform endPosition;
    public float speedUp = 1.5f;
    public float speedDown = 1f;
    public bool hastomove;

    void Update()
    {
        if(hastomove){
            platform.position = Vector2.MoveTowards(platform.position,endPosition.position,speedUp*Time.deltaTime);
        }
        else{
            platform.position = Vector2.MoveTowards(platform.position,startPosition.position,speedDown*Time.deltaTime);
        }
    }
}
