using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddel : MonoBehaviour
{
    private Rigidbody rb;
    private float t;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        rb.velocity = new Vector3(Random.Range(-1, 2), 0, 0);
    }

    private void Move()
    {

    }
}
