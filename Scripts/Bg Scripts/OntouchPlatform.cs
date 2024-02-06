using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class OntouchPlatform : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D target)
    {
        OnTouchMovement otm = transform.parent.GetComponent<OnTouchMovement>();
        otm.hastomove = true;    
    }
    void OnCollisionExit2D(Collision2D target)
    {
        OnTouchMovement otm = transform.parent.GetComponent<OnTouchMovement>();
        otm.hastomove = false;  
    }
}
