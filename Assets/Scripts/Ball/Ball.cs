using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Ball : MonoBehaviour
{
    [SerializeField]
    private float speed = 1;
    private bool up = false, down = true, left = false, right = true;
    public Action BallDies;

    void Update()
    {
        if (up)
        {
            transform.Translate(0, speed * Time.deltaTime, 0);
        }
        if (down)
        {
            transform.Translate(0, -speed * Time.deltaTime, 0);
        }
        if (right)
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
        }
        if (left)
        {
            transform.Translate(-speed * Time.deltaTime, 0, 0);
        }
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Top" || col.gameObject.tag == "Player")//top
        {
            down = false;
            up = true;            
        }
        if (col.gameObject.tag == "Left")//left
        {
            left = false;
            right = true;
        }
        if (col.gameObject.tag == "Right")//right
        {
            right = false;
            left = true;
        }

        if (col.gameObject.tag == "Bottom")//bottom 
        {
            up = false;
            down = true;            
        }

        if (col.gameObject.tag == "Wall")//bottom 
        {
            BallDies();
            Destroy(gameObject);
        }

    }
}
