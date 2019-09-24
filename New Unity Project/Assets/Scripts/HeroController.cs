using System;
using System.Collections;
using System.Collections.Generic;
using ProBuilder2.Common;
using UnityEngine;
using UnityEngine.EventSystems;

public class HeroController : MonoBehaviour
{
    public Transform _dest;
    public float _rotateSpeed;
    public float _stopSpeed;
    public float _radius;
    public float _lifes = 3;

    private void FixedUpdate()
    {
        if (Input.GetAxis("Jump") > 0)
        {
            AngularMovement(_stopSpeed);
        }
        else
        {
            AngularMovement(_rotateSpeed);
        }
        
    }

    private float x, y, angle;
    private void AngularMovement(float speed)
    {
        var position = _dest.position;
        x = position.x + Mathf.Cos(angle) * _radius;
        y = position.y + Mathf.Sin(angle) * _radius;
        transform.position = new Vector2(x, y);
        angle = angle + Time.deltaTime * speed;
        if (angle >= 360)
            angle = 0;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("bump");
        if (--_lifes < 0)
        {
            Debug.Log("dead");
            Destroy(gameObject);
        }
    }
}
