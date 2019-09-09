using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed = 1;
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        transform.Translate(new Vector3(Input.GetAxis("Horizontal"), 0) * speed * Time.deltaTime);

    }
}
