using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    private bool isDead = false;
    private Rigidbody2D rb2d;
    public float upForce = 200f;
    private Animator anim;
    RotateBird rotateBird;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        rotateBird = GetComponent<RotateBird>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        if(isDead == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                rb2d.velocity = Vector2.zero;
                rb2d.AddForce(Vector2.up * upForce);
                anim.SetTrigger("Flap");
                SoundSystem.instance.PlayAudioFlap();
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isDead = true;
        anim.SetTrigger("Die");
        rotateBird.enabled = false;
        Invoke("BirdDie",1.5f);
        rb2d.velocity = Vector2.zero;
        SoundSystem.instance.PlayAudioHit();
    }

    void BirdDie()
    {
        GameControler.instance.BirdDie();
    }
}
