using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBird : MonoBehaviour
{
    public float maxDownVelocity = -7f;
    public float maxDownAngle = -45f;

    Rigidbody2D rb2d;

    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (rb2d) //si existe 
        {
            float currentVelocity = Mathf.Clamp(rb2d.velocity.y, maxDownVelocity, 0);
            float angle = (currentVelocity / maxDownVelocity) * maxDownAngle;
            Quaternion rotation = Quaternion.Euler(0, 0, angle);
            transform.rotation = rotation;
        }
    }
}
