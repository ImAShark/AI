using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField]
    private float speed = 1;
    private float curSpeed = 1;
    private Vector3 dir;

    void Start()
    {
        curSpeed = speed;
    }

    void Update()
    {
        transform.Translate(speed * Time.deltaTime, -curSpeed * Time.deltaTime, 0);
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Wall")
        {
            dir = Vector3.Reflect(dir, col.GetContact(0).normal);
        }

        if (col.gameObject.tag == "Player") 
        {
            dir = Vector3.Reflect(dir, col.GetContact(0).normal);
            curSpeed = -curSpeed;
        }

    }
}
