using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObjetc : MonoBehaviour
{
    Rigidbody2D rb2d;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        rb2d.velocity = new Vector2(GameControler.instance.scrollSpeed, 0);
    }   

    void Update()
    {
        if(GameControler.instance.gameOver == true)
        {
            rb2d.velocity = Vector2.zero;
        }
    }
}
