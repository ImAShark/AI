using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField]
    private float speed = 1;
    public bool up = false, down = true, left = false, right = true;


    void Start()
    {
        
    }

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
        if (col.gameObject.name == "Wall1" || col.gameObject.name == "Bottom")//top
        {
            up = false;
            down = true;
        }
        if (col.gameObject.name == "Wall2" || col.gameObject.name == "RightSide")//left
        {
            left = false;
            right = true;
        }
        if (col.gameObject.name == "Wall3" || col.gameObject.name == "LeftSide")//right
        {
            right = false;
            left = true;
        }

        if (col.gameObject.tag == "Player" || col.gameObject.name == "Top")//bottom 
        {
            down = false;
            up = true;
        }

    }
}
