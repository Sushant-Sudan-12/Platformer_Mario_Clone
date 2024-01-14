using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleBackground : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        transform.localScale = new Vector3(1,1,1);

        float width = sr.sprite.bounds.size.x;
        float height = sr.sprite.bounds.size.y;

        float world_height = Camera.main.orthographicSize*2f;
        float world_width = world_height/Screen.height*Screen.width;

        Vector3 tempScale = transform.localScale;
        tempScale.x = world_width/width;
        tempScale.y = world_height/height;
        transform.localScale = tempScale;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
