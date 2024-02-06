using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformStand : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        

        collision.transform.SetParent(transform.parent);

   
        

    }

    void OnCollisionExit2D(Collision2D collision)
    {
        collision.transform.SetParent(null);
    }
}
