using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fondo : MonoBehaviour
{
    public SpriteRenderer miSpriteRenderer;
    public float speed = 2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        miSpriteRenderer.size += new Vector2(0, 1) * speed * Time.deltaTime;
    }
}
