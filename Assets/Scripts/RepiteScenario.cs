using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepiteScenario : MonoBehaviour
{
    BoxCollider2D groundCollider;
    float groundHorizontallenght;

    private void Awake()
    {
        groundCollider = GetComponent<BoxCollider2D>();
    }

    void Start()
    {
        groundHorizontallenght = groundCollider.size.x;        
    }

    void RepositionBackground()
    {
        transform.Translate(Vector2.right * groundHorizontallenght * 2);
    }

    void Update()
    {
        if(transform.position.x < -groundHorizontallenght)
        {
            RepositionBackground();
        }
    }
}
